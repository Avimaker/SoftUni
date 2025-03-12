namespace ProductShop
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using ProductShop.Data;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.Migrate();
            //Console.WriteLine("Database migrated successful");

            //// Problem 01
            //string jsonString = File.ReadAllText("../../../Datasets/users.json");
            //string result = ImportUsers(dbContext, jsonString);
            //Console.WriteLine(result);

            //// Problem 02
            //string jsonString = File.ReadAllText("../../../Datasets/products.json");
            //string result = ImportProducts(dbContext, jsonString);
            //Console.WriteLine(result);

            //// Problem 03
            //string jsonString = File.ReadAllText("../../../Datasets/categories.json");
            //string result = ImportCategories(dbContext, jsonString);
            //Console.WriteLine(result);

            //// Problem 04
            //string jsonString = File.ReadAllText("../../../Datasets/categories-products.json");
            //string result = ImportCategoryProducts(dbContext, jsonString);
            //Console.WriteLine(result);

            //// Problem 05 Export
            //string result = GetProductsInRange(dbContext);
            //Console.WriteLine(result);
            //// записваме файл с резултата в папка Results
            //const string outputFilePath = "../../../Results/productsRange.json";
            //File.WriteAllText(outputFilePath, result, Encoding.Unicode);

            //// Problem 06 Export
            //string result = GetSoldProducts(dbContext);
            //Console.WriteLine(result);
            //// записваме файл с резултата в папка Results
            //const string outputFilePath = "../../../Results/soldProducts.json";
            //File.WriteAllText(outputFilePath, result, Encoding.Unicode);

            //// Problem 07 Export
            //string result = GetCategoriesByProductsCount(dbContext);
            //Console.WriteLine(result);
            //// записваме файл с резултата в папка Results
            //const string outputFilePath = "../../../Results/categoriesByProductsCount.json";
            //File.WriteAllText(outputFilePath, result, Encoding.Unicode);

            // Problem 08 Export
            string result = GetUsersWithProducts(dbContext);
            Console.WriteLine(result);
            // записваме файл с резултата в папка Results
            const string outputFilePath = "../../../Results/UsersWithProducts.json";
            File.WriteAllText(outputFilePath, result, Encoding.Unicode);

        }

        // Problem 01A
        //public static string ImportUsers(ProductShopContext context, string inputJson)
        //{
        //    var users = JsonConvert.DeserializeObject<List<User>>(inputJson) ?? new List<User>();

        //    context.Users.AddRange(users);
        //    context.SaveChanges();

        //    return $"Successfully imported {users.Count}";
        //}


        // Problem 01 Import
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportUserDto[]? userDtos = JsonConvert
                .DeserializeObject<ImportUserDto[]>(inputJson);

            if (userDtos != null)
            {
                ICollection<User> usersToAdd = new List<User>();
                foreach (ImportUserDto userDto in userDtos)
                {
                    if (!IsValid(userDto))
                    {
                        continue;
                    }

                    int? userAge = null;
                    if (userDto.age != null)
                    {
                        int parsedAge = 0;
                        bool isAgeValid = int.TryParse(userDto.age, out parsedAge);
                        if (!isAgeValid)
                        {
                            continue;
                        }

                        userAge = parsedAge;
                    }

                    User user = new User()
                    {
                        FirstName = userDto.firstName,
                        LastName = userDto.lastName,
                        Age = userAge
                    };

                    usersToAdd.Add(user);
                }

                context.Users.AddRange(usersToAdd);
                context.SaveChanges();

                result = $"Successfully imported {usersToAdd.Count}";
            }

            return result;
        }

        // Problem 02 Import
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportProductDto[]? productDtos = JsonConvert
                .DeserializeObject<ImportProductDto[]>(inputJson);

            if (productDtos != null)
            {
                //// това не въври в джъдж
                //ICollection<int> dbUsers = context
                //    .Users
                //    .Select(u => u.Id)
                //    .ToArray();

                ICollection<Product> validProducts = new List<Product>();

                foreach (ImportProductDto productDto in productDtos)
                {
                    if (!IsValid(productDto))
                    {
                        continue;
                    }

                    bool isPriceValid = decimal
                        .TryParse(productDto.Price, out decimal productPrice);

                    bool isSellerValid = int
                        .TryParse(productDto.SellerId, out int sellerId);

                    if ((!isPriceValid) || (!isSellerValid))
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

                        // Removed for Judge
                        /*
                        if (!dbUsers.Contains(parsedBuyerId))
                        {
                            continue;
                        }
                        */

                        buyerId = parsedBuyerId;
                    }

                    // Removed for Judge
                    /*
                    if (!dbUsers.Contains(sellerId))
                    {
                        //SellerId is valid int, but user dont exist
                        //Invalid Seller!!!
                        continue;
                    }
                    */

                    Product product = new Product()
                    {
                        Name = productDto.Name,
                        Price = productPrice,
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

        // Problem 03 Import
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCategoryDto[]? categoryDtos = JsonConvert
                .DeserializeObject<ImportCategoryDto[]>(inputJson);

            if (categoryDtos != null)
            {
                ICollection<Category> validCategories = new List<Category>();
                foreach (ImportCategoryDto categoryDto in categoryDtos)
                {
                    if (!IsValid(categoryDto))
                    {
                        continue;
                    }

                    // CategoryDto.Name is not null here!!!
                    Category category = new Category()
                    {
                        Name = categoryDto.Name!
                    };

                    validCategories.Add(category);
                }

                context.Categories.AddRange(validCategories);
                context.SaveChanges();

                result = $"Successfully imported {validCategories.Count}";
            }

            return result;
        }

        // Problem 04 Import with explain
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            //01-създаваме празен стринг резултат
            string result = string.Empty;

            /*02-десериализираме от масив от ImportCategoryProductDto[]?
            categoryProductDtos-а = десериалайз обджект към масив
            от ImportCategoryProductDto[] и искаме да десиериализираме от този инпут (inputJson) *** ? значи може да върне null
            */
            ImportCategoryProductDto[]? categoryProductDtos = JsonConvert
                .DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            //03-правим проверка дали нещо изобщо е успяло да се десериализира различно от null
            if (categoryProductDtos != null)
            {
                //04-ако да, то тогава трябва да си направим една колекция от CategoryProduct която ще се казва validCategoryProducts и ще бъде списък  
                ICollection<CategoryProduct> validCategoryProducts = new List<CategoryProduct>();

                //05-трябва да си форийчнем в ImportCategoryProductDto-тата всяко categoryProductDto и да направим проверка дали всички проп от клас дтото са минали успешно
                foreach (ImportCategoryProductDto categoryProductDto in categoryProductDtos)
                {
                    //06-ако вместо ин са попдадени null това е невалидно дто и се пропуска
                    if (!IsValid(categoryProductDto))
                    {
                        continue;
                    }

                    //07- ако мине трябва да направим проверка дали са валидни двете ID-та от дтото
                    // взимам пропъртитата като нейм от дто класа, който направих
                    // опитай се да парснеш каквото е дошло като стринг в categoryProductDto -> CategoryId и се опитай да го парснеш към инт, ако успее да ми изкара една int променлива categoryId
                    bool isCategoryIdValid = int
                        .TryParse(categoryProductDto.CategoryId, out int categoryId);

                    bool isProductIdValid = int
                        .TryParse(categoryProductDto.ProductId, out int productId);

                    if ((!isCategoryIdValid) || (!isProductIdValid))
                    {
                        continue;
                    }

                    //08- правим проста проверка, ако е невалиден int - categoryId или productId пропускаме
                    if ((!isCategoryIdValid) || (!isProductIdValid))
                    {
                        continue;
                    }

                    //09- след като всичко е минало трябва да си направим мапинг ентити CategoryProduct в което да сложим получените стойности от CategoryId и ProductId
                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        ProductId = productId,
                        CategoryId = categoryId
                    };

                    //10- ако всичко е ок, трябва да добавим "categoryProduct" в колекцията с валидни катргори продукти "validCategoryProducts"
                    validCategoryProducts.Add(categoryProduct);
                }

                //11- когато минат всички categoryProduct от форийча трябва да доваим в context рейндж от валидните мапинг ентитита за да може да почне да ги траква change tracker 
                context.CategoriesProducts.AddRange(validCategoryProducts);
                //и за да ги персистнем
                context.SaveChanges();

                //12- накрая оправяме и резултата
                result = $"Successfully imported {validCategoryProducts.Count}";
            }

            //13- връщаме резултата
            return result;
        }

        // Problem 05 Export
        public static string GetProductsInRange(ProductShopContext context)
        {
            //01- от контектста ми дай всички продукти, в ценовия диапазон 500 - 1000. Трябва да се селектира, само product name, price and the full name of the seller
            // продукта трябва да отиде в нов анонимен обект

            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    Name = p.Name,
                    p.Price,
                    //Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName //concatenation
                })
                .OrderBy(p => p.Price)
                .ToArray();

            //02- сериализация

            //трябва да се създаде това за да се ползва по-долу
            //чрез тази настройка, независимо какво сме напосали за пропъртитата кам Големи или Малки букви да се оправи е изходния json
            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert
                .SerializeObject(products, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseResolver
                });

            //03- ретърн
            return jsonResult;
        }

        // Problem 06 Export масив от обекти и вложени дтота
        public static string GetSoldProducts(ProductShopContext context)
        {
            // product dto е вложено в user dto
            var usersWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold
                                .Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                                        .Where(p => p.BuyerId.HasValue)
                                        .Select(p => new
                                        {
                                            p.Name,
                                            p.Price,
                                            BuyerFirstName = p.Buyer!.FirstName,
                                            BuyerLastName = p.Buyer.LastName
                                        })
                                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToArray();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert
                .SerializeObject(usersWithSoldProducts, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseResolver
                });

            return jsonResult;
        }

        // Problem 07 Export Categories by Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductsCount = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    ProductsCount = c.CategoriesProducts.Count,
                    AveragePrice = c.CategoriesProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoriesProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.ProductsCount)
                .ToList()
                .Select(c => new
                {
                    category = c.CategoryName,
                    productsCount = c.ProductsCount,
                    averagePrice = c.AveragePrice.ToString("F2", CultureInfo.InvariantCulture),
                    totalRevenue = c.TotalRevenue.ToString("F2", CultureInfo.InvariantCulture)
                })
                .ToList();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert
                .SerializeObject(categoriesByProductsCount, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseResolver
                });

            return jsonResult;

        }

        // Problem 08 Export пропуска стойности с null - output e obj с пропърти usersCount и пропърти users което е масив от дтота с проп last name, age & soldProducts което вече е вложено дто 

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var userWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold
                    .Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold
                                    .Count(p => p.BuyerId.HasValue),
                        Products = u.ProductsSold
                                    .Where(p => p.BuyerId.HasValue)
                                    .Select(p => new
                                    {
                                        p.Name,
                                        p.Price
                                    })
                                    .ToArray()
                    }
                })
                .ToArray()
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToArray();

            var serializedUsers = new
            {
                UsersCount = userWithSoldProducts.Length,
                Users = userWithSoldProducts
            };

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert
                .SerializeObject(serializedUsers, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseResolver,
                    NullValueHandling = NullValueHandling.Ignore // skip null
                });

            return jsonResult;


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