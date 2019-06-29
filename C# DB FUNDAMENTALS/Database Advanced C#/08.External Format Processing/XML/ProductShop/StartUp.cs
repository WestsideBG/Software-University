namespace ProductShop
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore.Internal;
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
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
            using (var context = new ProductShopContext())
            {
                Mapper.Initialize(x =>
                {
                    x.AddProfile<ProductShopProfile>();
                });

                //Create Database
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                Console.WriteLine(GetUsersWithProducts(context));

                
            }
        }

        private static void ImportData(ProductShopContext context)
        {
            var xmlUsers =
                File.ReadAllText(
                    @"D:\Desktop\Softuni\C# DB FUNDAMENTALS\Database Advanced C#\08.External Format Processing\XML\ProductShop\Datasets\users.xml");

            var xmlProducts =
                File.ReadAllText(
                    @"D:\Desktop\Softuni\C# DB FUNDAMENTALS\Database Advanced C#\08.External Format Processing\XML\ProductShop\Datasets\products.xml");

            var xmlCategories =
                File.ReadAllText(
                    @"D:\Desktop\Softuni\C# DB FUNDAMENTALS\Database Advanced C#\08.External Format Processing\XML\ProductShop\Datasets\categories.xml");

            var xmlCategoryProducts = File.ReadAllText(
                @"D:\Desktop\Softuni\C# DB FUNDAMENTALS\Database Advanced C#\08.External Format Processing\XML\ProductShop\Datasets\categories-products.xml");

            Console.WriteLine(ImportUsers(context, xmlUsers));
            Console.WriteLine(ImportProducts(context, xmlProducts));
            Console.WriteLine(ImportCategories(context, xmlCategories));
            Console.WriteLine(ImportCategoryProducts(context, xmlCategoryProducts));

        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportUsersDto[]), new XmlRootAttribute("Users"));

            var users = (ImportUsersDto[])serializer.Deserialize(new StringReader(inputXml));

            var mappedUsers = new List<User>();

            foreach (var userDto in users)
            {
                var user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age
                };

                mappedUsers.Add(user);
            }

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            var productsDto = (ImportProductDto[])serializer.Deserialize(new StringReader(inputXml));

            var mappedProducts = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = Mapper.Map<Product>(productDto);

                mappedProducts.Add(product);
            }

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedProducts.Count}";

        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            var categoryDtos = (ImportCategoryDto[])serializer.Deserialize(new StringReader(inputXml));

            var mappedCategories = new List<Category>();

            foreach (var categoryDto in categoryDtos)
            {
                var category = Mapper.Map<Category>(categoryDto);

                mappedCategories.Add(category);
            }

            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            var categoryProductsDto = (ImportCategoryProductDto[])serializer.Deserialize(new StringReader(inputXml));

            var mappedCategoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoryProductsDto)
            {
                var category = context.Categories.Find(categoryProductDto.CategoryId);
                var product = context.Products.Find(categoryProductDto.ProductId);

                if (category != null && product != null)
                {
                    var categoryProduct = new CategoryProduct()
                    {
                        CategoryId = category.Id,
                        ProductId = product.Id
                    };

                    mappedCategoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(mappedCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedCategoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var serializer = new XmlSerializer(typeof(ProductInRangeDto[]), new XmlRootAttribute("Products"));

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any() && u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new SellerDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Where(p => p.Buyer != null).Select(p => new SoldProductDto()
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToList()
                })
                .Take(5)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(SellerDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoryByProductDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Select(p => p.Product.Price).Average(),
                    TotalRevenue = c.CategoryProducts.Select(p => p.Product.Price).Sum()
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCategoryByProductDto[]), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                .Select(u => new UserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductWithCountDto()
                    {
                        Count = u.ProductsSold.Count(ps => ps.Buyer != null),
                        SoldProducts = u.ProductsSold
                            .Where(ps => ps.Buyer != null)
                            .Select(p => new SoldProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .Take(10)
                .ToArray();


            var result = new ExportUsersWithProductsDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = users
            };


            XmlSerializer serializer = new XmlSerializer(typeof(ExportUsersWithProductsDto), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            serializer.Serialize(new StringWriter(sb), result, namespaces);

            return sb.ToString();
        }
    }
}