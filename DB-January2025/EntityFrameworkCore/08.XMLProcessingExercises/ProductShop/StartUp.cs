using ProductShop.DTOs.Export;

namespace ProductShop
{
    using Data;
    using DTOs.Import;
    using Utilities;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //const string xmlFilePath = "../../../Datasets/categories-products.xml";
            //string inputXml = File.ReadAllText(xmlFilePath);

            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            string result = string.Empty;

            ImportUserDto[] usersDto = XmlHelper.Deserialize<ImportUserDto[]>(inputXml, "Users");

            if (usersDto != null)
            {
                ICollection<User> users = new List<User>();

                foreach (ImportUserDto userDto in usersDto)
                {
                    if (!Validation.IsValid(userDto)) continue;

                    if (!int.TryParse(userDto.Age, out int validAge)) continue;

                    User user = new User
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Age = validAge
                    };

                    users.Add(user);
                }

                context.Users.AddRange(users);
                context.SaveChanges();

                result = $"Successfully imported {users.Count}";
            }

            return result;
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            string result = string.Empty;

            ImportProductDto[] productsDto = XmlHelper.Deserialize<ImportProductDto[]>(inputXml, "Products");

            if (productsDto != null)
            {
                ICollection<Product> products = new List<Product>();
                foreach (ImportProductDto productDto in productsDto)
                {
                    if (!Validation.IsValid(productDto) ||
                        !decimal.TryParse(productDto.Price, out decimal validPrice) ||
                        !int.TryParse(productDto.SellerId, out int validSellerId)) continue;

                    int? buyerId = null;

                    if (productDto.BuyerId != null && int.TryParse(productDto.BuyerId, out int validBuyerId))
                    {
                        buyerId = validBuyerId;
                    }

                    Product product = new Product
                    {
                        Name = productDto.Name,
                        Price = validPrice,
                        SellerId = validSellerId,
                        BuyerId = buyerId
                    };
                    products.Add(product);
                }

                context.Products.AddRange(products);
                context.SaveChanges();

                result = $"Successfully imported {products.Count}";
            }

            return result;
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            string result = string.Empty;

            ImportCategoryDto[] categoriesDto = XmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

            if (categoriesDto != null)
            {
                ICollection<Category> categories = new List<Category>();

                foreach (ImportCategoryDto categoryDto in categoriesDto)
                {
                    if (!Validation.IsValid(categoryDto)) continue;

                    Category category = new Category
                    {
                        Name = categoryDto.Name
                    };

                    categories.Add(category);
                }

                context.Categories.AddRange(categories);
                context.SaveChanges();

                result = $"Successfully imported {categories.Count}";
            }

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            string result = string.Empty;

            ImportCategoryProductDto[] categoryProductsDto =
                XmlHelper.Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");

            if (categoryProductsDto != null)
            {
                ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();

                var categoriesId = context.Categories.Select(c => c.Id).ToHashSet();
                var productsId = context.Products.Select(p => p.Id).ToHashSet();

                foreach (ImportCategoryProductDto categoryProductDto in categoryProductsDto)
                {
                    if (!int.TryParse(categoryProductDto.CategoryId, out int validCategoryId) ||
                        !int.TryParse(categoryProductDto.ProductId, out int validProductId)) continue;

                    if (!Validation.IsValid(categoryProductDto) ||
                        !categoriesId.Contains(validCategoryId) ||
                        !productsId.Contains(validProductId)) continue;

                    CategoryProduct categoryProduct = new CategoryProduct
                    {
                        CategoryId = validCategoryId,
                        ProductId = validProductId
                    };
                    categoryProducts.Add(categoryProduct);
                }

                context.CategoryProducts.AddRange(categoryProducts);
                context.SaveChanges();

                result = $"Successfully imported {categoryProducts.Count}";
            }

            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price.ToString(),
                    Buyer = p.Buyer != null ? (p.Buyer.FirstName + ' ' + p.Buyer.LastName) : " "
                })
                .Take(10)
                .ToArray();

            return XmlHelper.Serialize(products, "Products");
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new ExportUserSoldProductsDto()
                {
                    FirstName = u.FirstName != null ? u.FirstName : " ",
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(ps => new ExportProductDto()
                        {
                            Name = ps.Name,
                            Price = ps.Price.ToString()
                        })
                        .ToArray()
                })
                .Take(5)
                .ToArray();

            return XmlHelper.Serialize(users, "Users");
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoryByProductsCountDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            return XmlHelper.Serialize(categories, "Categories");
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new ExportUserWithProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsDto()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                            .OrderByDescending(ps => ps.Price)
                            .Select(ps => new ExportProductDto()
                            {
                                Name = ps.Name,
                                Price = ps.Price.ToString()
                            })
                            .ToArray()
                    }
                })
                .Take(10)
                .ToArray();
            var result = new ExportUsersAndProductsDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any(ps => ps.Buyer != null)),
                Users = users
            };
            return XmlHelper.Serialize(result, "Users");
        }
    }
}