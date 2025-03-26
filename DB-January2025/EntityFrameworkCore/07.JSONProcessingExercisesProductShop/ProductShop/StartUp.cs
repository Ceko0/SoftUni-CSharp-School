

namespace ProductShop
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using DTOs.Import;
    using Models;
    using Data;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main()
        {

            ProductShopContext context = new ProductShopContext();

            string jsonString = File.ReadAllText("../../../Datasets/categories-products.json");


            string result = GetUsersWithProducts(context);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            var validUsers = new List<User>();
            foreach (var userDto in users)
            {
                if (!IsValid(userDto))
                {
                    continue;
                }
                var user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age
                };
                validUsers.Add(user);
            }
            context.Users.AddRange(validUsers);
            context.SaveChanges();
            return $"Successfully imported {validUsers.Count}";

        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            var validProducts = new List<Product>();

            if (products != null)
            {

                foreach (var productDto in products)
                {
                    if (!IsValid(productDto))
                    {
                        continue;
                    }

                    bool price = decimal.TryParse(productDto.Price, out decimal validPrice);
                    bool seller = int.TryParse(productDto.SellerId, out int validSellerId);
                    if (!price || !seller)
                    {
                        continue;
                    }

                    int? validBuyerId = null;
                    if (productDto.BuyerId != null)
                    {
                        bool buyer = int.TryParse(productDto.BuyerId, out int testedBuyerId);
                        if (!buyer)
                        {
                            continue;
                        }
                        validBuyerId = testedBuyerId;
                    }

                    var product = new Product()
                    {
                        Name = productDto.Name,
                        Price = validPrice,
                        SellerId = validSellerId,
                        BuyerId = validBuyerId
                    };

                    validProducts.Add(product);
                }

                context.Products.AddRange(validProducts);
                context.SaveChanges();

            }
            return $"Successfully imported {validProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);
            var validCategories = new List<Category>();

            if (categories != null)
            {
                foreach (var categoryDto in categories)
                {
                    if (!IsValid(categoryDto))
                    {
                        continue;
                    }

                    var category = new Category()
                    {
                        Name = categoryDto.Name
                    };
                    validCategories.Add(category);
                }

                context.Categories.AddRange(validCategories);
                context.SaveChanges();
            }

            return $"Successfully imported {validCategories.Count}";

        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            var validCategoryProducts = new List<CategoryProduct>();

            if (categoriesProducts != null)
            {
                //ICollection<int> dbProducts = context
                //    .Products
                //    .Select(p => p.Id)
                //    .ToArray();
                //ICollection<int> dbCategories = context
                //    .Categories
                //    .Select(c => c.Id)
                //    .ToArray();

                foreach (var categoryProductDto in categoriesProducts)
                {
                    if (!IsValid(categoryProductDto))
                    {
                        continue;
                    }

                    bool product = int.TryParse(categoryProductDto.ProductId, out int validProductId);
                    bool category = int.TryParse(categoryProductDto.CategoryId, out int validCategoryId);

                    if ((!product) || (!category))
                    {
                        continue;
                    }

                    //bool categoryExists = dbCategories.Any(c => c == validCategoryId);
                    //if (!categoryExists)
                    //{
                    //    continue;
                    //}

                    //bool productExists = dbProducts.Any(p => p == validProductId);
                    //if (!categoryExists)
                    //{
                    //    continue;
                    //}

                    var categoryProduct = new CategoryProduct()
                    {
                        ProductId = validProductId,
                        CategoryId = validCategoryId
                    };

                    validCategoryProducts.Add(categoryProduct);
                }

                context.CategoriesProducts.AddRange(validCategoryProducts);

                context.SaveChanges();
            }

            return $"Successfully imported {validCategoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(p => p.price)
                .ToList();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert
                .SerializeObject(products, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseResolver
                });

            return jsonResult;

        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.BuyerId.HasValue)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            buyerFirstName = p.Buyer!.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName);

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert
                .SerializeObject(users, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseResolver
                });

            return jsonResult;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = c.CategoriesProducts.Average(cp => cp.Product.Price).ToString("F2"),
                    totalRevenue = c.CategoriesProducts.Sum(cp => cp.Product.Price).ToString("F2")
                })
                .OrderByDescending(c => c.productsCount)
                .ToList();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert
                .SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseResolver
                });

            return jsonResult;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Where(p => p.BuyerId.HasValue).Count(),
                        products = u.ProductsSold
                            .Where(p => p.BuyerId.HasValue)
                            .Select(p => new
                            {
                                p.Name,
                                p.Price
                            })
                    }
                })
                .ToList()
                .OrderByDescending(u => u.soldProducts.count)
                .ToList();

            var resultObj = new { usersCount = users.Count, users };

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert
                .SerializeObject(resultObj, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseResolver,
                    NullValueHandling = NullValueHandling.Ignore
                });
            return jsonResult;
        }

        //helper method
        private static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResults, true);

            return isValid;
        }
    }
}