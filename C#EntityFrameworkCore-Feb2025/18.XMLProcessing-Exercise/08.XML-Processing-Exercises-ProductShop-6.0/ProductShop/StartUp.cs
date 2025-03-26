using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();
            //dbContext.Database.Migrate();
            //Console.WriteLine("Db Migrated Succesfuly!");

            ////Query 1. Import Users
            //const string xmlFilePath = "../../../Datasets/users.xml";
            //string inputXml = File.ReadAllText(xmlFilePath);
            //string result = ImportUsers(dbContext, inputXml);
            //Console.WriteLine(result);

            ////Query 2. Import Products
            //const string xmlFilePath = "../../../Datasets/products.xml";
            //string inputXml = File.ReadAllText(xmlFilePath);
            //string result = ImportProducts(dbContext, inputXml);
            //Console.WriteLine(result);

            ////Query 3.Import Categories
            //const string xmlFilePath = "../../../Datasets/categories.xml";
            //string inputXml = File.ReadAllText(xmlFilePath);
            //string result = ImportCategories(dbContext, inputXml);
            //Console.WriteLine(result);

            ////Query 4. Import Categories and Products
            //const string xmlFilePath = "../../../Datasets/categories-products.xml";
            //string inputXml = File.ReadAllText(xmlFilePath);
            //string result = ImportCategoryProducts(dbContext, inputXml);
            //Console.WriteLine(result);

            ////Query 5. Export Products In Range
            //string result = GetProductsInRange(dbContext);
            //Console.WriteLine(result);
            //const string xmlFilePath = "../../../Results/products-in-range.xml";
            //File.WriteAllText(xmlFilePath, result);

            ////Query 6. Export Sold Products
            //string result = GetSoldProducts(dbContext);
            //Console.WriteLine(result);
            //const string xmlFilePath = "../../../Results/users-sold-products.xml";
            //File.WriteAllText(xmlFilePath, result);

            ////Query 7. Export Categories By Products Count
            //string result = GetCategoriesByProductsCount(dbContext);
            //Console.WriteLine(result);
            //const string xmlFilePath = "../../../Results/categories-by-products.xml";
            //File.WriteAllText(xmlFilePath, result);

            //Query 8. Export Users and Products
            string result = GetUsersWithProducts(dbContext);
            Console.WriteLine(result);
            const string xmlFilePath = "../../../Results/users-and-products.xml";
            File.WriteAllText(xmlFilePath, result);


        }

        //Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            //1st create empty string
            string result = string.Empty;

            //use dto that already create plus root name + XmlHelper
            ImportUserDto[]? importUserDtos = XmlHelper
                .Deserialize<ImportUserDto[]>(inputXml, "Users");

            if (importUserDtos != null) //if no data - skip
            {
                //ако има данни правим колекция
                ICollection<User> validUsers = new List<User>();

                //завъртаме циъл
                foreach (ImportUserDto importUserDto in importUserDtos)
                {
                    //first check if the dto isValid
                    if (!IsValid(importUserDto))
                    {
                        continue;
                    }

                    //if it is valid we have to check parse props from dto
                    bool isAgeValid = int.TryParse(importUserDto.Age, out int age);

                    //check if some of them are invalid we have to skip
                    if (!isAgeValid)
                    {
                        continue;
                    }

                    // ако сме минали всички проверки успешно трябва да направим инстанция на частта която ще съдържа валидната информация
                    User user = new User()
                    {
                        FirstName = importUserDto.FirstName,
                        LastName = importUserDto.LastName,
                        Age = age
                    };

                    //добавяме я към колекцията от валидните части
                    validUsers.Add(user);
                }

                //след форича в контекста през диби сета за частите трябва да добавя новите валидни части чрез ад реиндж.
                context.Users.AddRange(validUsers);

                // тригерирам запазване на промени
                context.SaveChanges();

                //ако всичко мине ок запазваме в резултат
                result = $"Successfully imported {validUsers.Count}";

            }

            return result;
        }

        //Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {

            string result = string.Empty;

            ImportProductDto[]? productDtos = XmlHelper
                .Deserialize<ImportProductDto[]>(inputXml, "Products");

            if (productDtos != null)
            {

                ICollection<Product> validProducts = new List<Product>();

                foreach (ImportProductDto productDto in productDtos)
                {
                    ICollection<int> dbUsers = context
                    .Users
                    .Select(u => u.Id)
                    .ToArray();

                    if (!IsValid(productDto))
                    {
                        continue;
                    }

                    bool isPriceValid = decimal.TryParse(productDto.Price, out decimal price);
                    bool isSellerIdValid = int.TryParse(productDto.SellerId, out int sellerId);


                    if ((!isPriceValid) || (!isSellerIdValid))
                    {
                        continue;
                    }

                    int? buyerId = null;
                    if (productDto.BuyerId != null)
                    {
                        bool isBuyerIdValid = int
                            .TryParse(productDto.BuyerId, out int parsedBuyerId);
                        if (!isBuyerIdValid)
                        {
                            continue;
                        }

                        buyerId = parsedBuyerId;
                    }


                    Product product = new Product()
                    {
                        Name = productDto.Name,
                        Price = price,
                        SellerId = sellerId,
                        BuyerId = buyerId
                    };

                    validProducts.Add(product);
                }

                context.Products.AddRange(validProducts);
                context.SaveChanges();

                result = $"Successfully imported {validProducts.Count}";
            }

            return result;
        }

        //Query 3.Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            string result = string.Empty;

            ImportCategoriesDto[]? categoriesDtos = XmlHelper
                .Deserialize<ImportCategoriesDto[]>(inputXml, "Categories");

            if (categoriesDtos != null)
            {
                ICollection<Category> validCategories = new List<Category>();

                foreach (ImportCategoriesDto categoriesDto in categoriesDtos)
                {
                    if (!IsValid(categoriesDto))
                    {
                        continue;
                    }

                    Category category = new Category()
                    {
                        Name = categoriesDto.Name
                    };

                    validCategories.Add(category);
                }

                context.Categories.AddRange(validCategories);
                context.SaveChanges();

                result = $"Successfully imported {validCategories.Count}";
            }

            return result;
        }

        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            string result = string.Empty;

            ImportCategoryProductsDto[]? categoriesDtos = XmlHelper
                .Deserialize<ImportCategoryProductsDto[]>(inputXml, "CategoryProducts");

            if (categoriesDtos != null)
            {
                ICollection<CategoryProduct> validCategoryProducts = new List<CategoryProduct>();

                foreach (ImportCategoryProductsDto categoriesDto in categoriesDtos)
                {
                    if (!IsValid(categoriesDto))
                    {
                        continue;
                    }

                    bool isCategoryIdValid = int.TryParse(categoriesDto.CategoryId, out int categoryId);
                    bool isProductIdValid = int.TryParse(categoriesDto.ProductId, out int productId);

                    if ((!isCategoryIdValid) || (!isProductIdValid))
                    {
                        continue;
                    }

                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryId,
                        ProductId = productId
                    };

                    validCategoryProducts.Add(categoryProduct);
                }

                context.CategoryProducts.AddRange(validCategoryProducts);
                context.SaveChanges();

                result = $"Successfully imported {validCategoryProducts.Count}";
            }

            return result;
        }

        //Export

        //Query 5. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {

            var productsInRangeDtos = context.
                Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new GetProductsInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer != null
                    ? $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                    : " "
                })
                .ToArray();

            string result = XmlHelper
                .Serialize(productsInRangeDtos, "Products");

            return result;
        }

        //Query 6. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            // Извличане на потребителите, които са продали поне един продукт
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null)) // Филтрираме само потребителите с продадени продукти
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5) // Взимаме първите 5 записа
                .Select(u => new ExportUserSoldProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null) // Филтрираме само продадените продукти
                        .Select(p => new ExportSoldProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .ToArray();

            // Сериализация на данните в XML формат
            string xmlResult = XmlHelper.Serialize(users, "Users");

            return xmlResult;

        }

        //Query 7. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            // Извличане на категориите с необходимите статистики
            var categories = context.Categories
                .Select(c => new ExportCategoryByProductsCountDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            // Сериализация на данните в XML формат
            string xmlResult = XmlHelper.Serialize(categories, "Categories");

            return xmlResult;
        }

        //Query 8. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            // Извличане на потребителите, които са продали поне един продукт
            var users = context
                .Users
                .Where(u => u.ProductsSold
                              .Any(p => p.Buyer != null)) // Филтрираме само потребителите с продадени продукти
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null)) // Сортиране по броя на продадените продукти
                //.Take(10) // Взимаме първите 10 записа
                .Select(u => new ExportUserWithProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsWrapperDto
                    {
                        Count = u.ProductsSold.Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null) // Филтрираме само продадените продукти
                            .OrderByDescending(p => p.Price) // Сортиране на продуктите по цена в низходящ ред
                            .Select(p => new ExportSoldProductDto
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .ToArray()
                    }
                })
                .ToArray();

            // Създаване на обвивката за XML
            var result = new ExportUsersWithProductsWrapperDto
            {
                Count = users.Length,
                Users = users
            };

            // това е хелпър метода
            //// Сериализация на данните в XML формат
            //string xmlResult = XmlHelper.Serialize(result, "Users");
            //return xmlResult;


            // Сериализация на данните в XML формат (без namespaces и без XML декларация)
            var serializer = new XmlSerializer(typeof(ExportUsersWithProductsWrapperDto));
            var settings = new XmlWriterSettings
            {
                Indent = true, // Форматиране на XML с отстъпи
                OmitXmlDeclaration = true // Премахване на XML декларацията
            };

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty); // Добавяме празно пространство от имена

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, result, namespaces);
                return stream.ToString();
            }


        }



        // helper method IsValid
        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResults, true);

            return isValid;
        }
    }
}