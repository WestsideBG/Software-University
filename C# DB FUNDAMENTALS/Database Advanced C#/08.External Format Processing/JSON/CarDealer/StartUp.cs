using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new CarDealerContext())
            {
                Console.WriteLine(GetSalesWithAppliedDiscount(context));
            }

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson);

            foreach (var part in parts)
            {
                if (context.Suppliers.Any(s => s.Id == part.SupplierId))
                {
                    context.Parts.Add(part);
                }
            }

            return $"Successfully imported {context.SaveChanges()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<CarsImportDto[]>(inputJson);

            foreach (var car in cars)
            {
                var mappedCar = new Car()
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    PartCars = car.PartCars,
                    Sales = car.Sales,
                    TravelledDistance = car.TravelledDistance
                };

                context.Cars.Add(mappedCar);

                car.PartsId = car.PartsId.Distinct().ToList();

                foreach (var id in car.PartsId)
                {
                    context.PartCars.Add(new PartCar()
                    {
                        Car = mappedCar,
                        Part = context.Parts.Find(id)
                    });
                }
            }

            context.SaveChanges();

            return $"Successfully imported {cars.Length}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new CustomersDto()
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var result = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy",
                Formatting = Formatting.Indented
            });

            return result;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ToyotaCarDto()
                {
                    Id = c.Id,
                    Make = c.Make,

                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);

            return jsonResult;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSupplierDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                }).ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars.Select(car => new CarPartsDto()
            {
                Car = new CarDto() { Make = car.Make, Model = car.Model, TravelledDistance = car.TravelledDistance },
                Parts = car.PartCars.Where(c => c.CarId == car.Id).Select(c => new PartDto()
                {
                    Name = c.Part.Name,
                    Price = $"{c.Part.Price:F2}"
                }).ToList()
            }).ToList();

            var result = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new CustomerDto()
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(s => new SalesDto()
            {
                Car = new CarDto()
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance
                },
                CustomerName = s.Customer.Name,
                Discount = $"{s.Discount:F2}",
                Price = $"{s.Car.PartCars.Where(pc => pc.CarId == s.CarId).Sum(p => p.Part.Price):F2}",
                PriceWithDiscount =
                    $"{s.Car.PartCars.Where(pc => pc.CarId == s.CarId).Sum(p => p.Part.Price) - (s.Car.PartCars.Where(pc => pc.CarId == s.CarId).Sum(p => p.Part.Price) * (s.Discount / 100)):F2}"
            }).Take(10).ToList();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }
    }
}