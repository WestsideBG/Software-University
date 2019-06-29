namespace CarDealer
{
    using Data;
    using Dtos.Export;
    using Dtos.Import;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (CarDealerContext context = new CarDealerContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //ImportData(context);

                Console.WriteLine(GetSalesWithAppliedDiscount(context));
            }
        }

        private static void ImportData(CarDealerContext context)
        {

            string suppliersXml = File.ReadAllText(@"D:\Desktop\Softuni\C# DB FUNDAMENTALS\Database Advanced C#\08.External Format Processing\XML\CarDealer\Datasets\suppliers.xml");
            string partsXml = File.ReadAllText(@"D:\Desktop\Softuni\C# DB FUNDAMENTALS\Database Advanced C#\08.External Format Processing\XML\CarDealer\Datasets\parts.xml");
            string carsXml = File.ReadAllText(@"D:\Desktop\Softuni\C# DB FUNDAMENTALS\Database Advanced C#\08.External Format Processing\XML\CarDealer\Datasets\cars.xml");
            string customersXml = File.ReadAllText(@"D:\Desktop\Softuni\C# DB FUNDAMENTALS\Database Advanced C#\08.External Format Processing\XML\CarDealer\Datasets\customers.xml");
            string salesXml = File.ReadAllText(@"D:\Desktop\Softuni\C# DB FUNDAMENTALS\Database Advanced C#\08.External Format Processing\XML\CarDealer\Datasets\sales.xml");


            Console.WriteLine(ImportSuppliers(context, suppliersXml));
            Console.WriteLine(ImportParts(context, partsXml));
            Console.WriteLine(ImportCars(context, carsXml));
            Console.WriteLine(ImportCustomers(context, customersXml));
            Console.WriteLine(ImportSales(context, salesXml));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            var suppliers = (ImportSupplierDto[])serializer.Deserialize(new StringReader(inputXml));

            var mappedSuppliers = new List<Supplier>();

            foreach (var supplier in suppliers)
            {
                var mappedSupplier = new Supplier
                {
                    Name = supplier.Name,
                    IsImporter = supplier.IsImporter
                };

                mappedSuppliers.Add(mappedSupplier);
            }

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            var parts = (ImportPartDto[])serializer.Deserialize(new StringReader(inputXml));

            var mappedParts = new List<Part>();

            foreach (var importPartDto in parts)
            {
                var part = new Part
                {
                    Name = importPartDto.Name,
                    Price = importPartDto.Price,
                    Quantity = importPartDto.Quantity,
                    SupplierId = importPartDto.SupplierId
                };

                if (context.Suppliers.Any(s => s.Id == part.SupplierId))
                {
                    mappedParts.Add(part);
                }
            }

            context.AddRange(mappedParts);
            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            var cars = (ImportCarDto[])serializer.Deserialize(new StringReader(inputXml));

            var mappedCars = new List<Car>();
            var mappedCarParts = new List<PartCar>();

            foreach (var importCarDto in cars)
            {

                var car = new Car
                {
                    Make = importCarDto.Make,
                    Model = importCarDto.Model,
                    TravelledDistance = importCarDto.TraveledDistance
                };

                mappedCars.Add(car);

                var partsId = importCarDto.PartsId.Select(p => p.PartId).ToArray();

                foreach (var id in partsId.Distinct())
                {
                    if (context.Parts.Any(p => p.Id == id))
                    {
                        var partCar = new PartCar
                        {
                            Car = car,
                            Part = context.Parts.Find(id)
                        };

                        mappedCarParts.Add(partCar);
                    }
                }
            }


            context.AddRange(mappedCars);
            context.AddRange(mappedCarParts);
            context.SaveChanges();

            return $"Successfully imported {mappedCars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            var customers = (ImportCustomerDto[])serializer.Deserialize(new StringReader(inputXml));

            var mappedCustomers = new List<Customer>();

            foreach (var customer in customers)
            {
                var mappedCustomer = new Customer()
                {
                    Name = customer.Name,
                    BirthDate = customer.BirthDate,
                    IsYoungDriver = customer.IsYoungDriver
                };

                mappedCustomers.Add(mappedCustomer);
            }

            context.Customers.AddRange(mappedCustomers);
            context.SaveChanges();

            return $"Successfully imported {mappedCustomers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSalesDto[]), new XmlRootAttribute("Sales"));

            var sales = (ImportSalesDto[])serializer.Deserialize(new StringReader(inputXml));

            var mappedSales = new List<Sale>();

            foreach (var sale in sales)
            {
                if (context.Cars.Any(c => c.Id == sale.CarId))
                {
                    var mappedSale = new Sale()
                    {
                        CarId = sale.CarId,
                        CustomerId = sale.CustomerId,
                        Discount = sale.Discount
                    };

                    mappedSales.Add(mappedSale);
                }
            }

            context.Sales.AddRange(mappedSales);
            context.SaveChanges();

            return $"Successfully imported {mappedSales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarDto[]), new XmlRootAttribute("cars"));
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new ExportCarDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .Take(10)
                .ToArray();


            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });
            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ExportBmwCarDto[]), new XmlRootAttribute("cars"));

            var bmwCars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportBmwCarDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                }).ToArray();

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("",""),
            });

            serializer.Serialize(new StringWriter(sb), bmwCars, namespaces);

            return sb.ToString();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ExportSupplierDto[]), new XmlRootAttribute("suppliers"));

            var localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                }).ToArray();

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            serializer.Serialize(new StringWriter(sb), localSuppliers, namespaces);

            return sb.ToString();

        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarWithPartDto[]), new XmlRootAttribute("cars"));

            var cars = context.Cars
                .Select(c => new ExportCarWithPartDto
            {
                Make = c.Make,
                Model = c.Model,
                Distance = c.TravelledDistance,
                Parts = c.PartCars
                    .Where(p => p.CarId == c.Id)
                    .Select(p => new ExportPartDto
                {
                    Name = p.Part.Name,
                    Price = p.Part.Price
                })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
            })
                .OrderByDescending(c => c.Distance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new []
            {
                new XmlQualifiedName("",""), 
            });

            serializer.Serialize(new StringWriter(sb), cars,namespaces);

            return sb.ToString();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCustomerDto[]), new XmlRootAttribute("customers"));

            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new ExportCustomerDto
                {
                    Name = c.Name,
                    CarsCount = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price)
)
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();



            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("",""),
            });

            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new ExportSaleDto
                {
                    Car = new ExportCarAttributeDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        Distance = s.Car.TravelledDistance
                    },

                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = (s.Car.PartCars.Sum(p => p.Part.Price) - (s.Car.PartCars.Sum(p => p.Part.Price) * (s.Discount / 100))).ToString("G29")
                }).ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportSaleDto[]), new XmlRootAttribute("sales"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("",""),
            });

            serializer.Serialize(new StringWriter(sb), sales, namespaces);

            return sb.ToString();
        }
    }
}