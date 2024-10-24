namespace DeskMarket.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using System.Security.Claims;

    using Data;
    using Data.Models;
    using Models;
    using static common.ValidationConstraints.Product;
    

    public class ProductController : Controller
    {
        private readonly ApplicationDbContext data;

        public ProductController(ApplicationDbContext context)
        {
            this.data = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();

            var products = await data.Products
                .Where(p => !p.IsDeleted)
                .Select(p => new IndexViewModel
                {
                    Id = p.Id.ToString(),
                    ImageUrl = p.ImageUrl ?? string.Empty,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    IsSeller = p.SellerId == userId,
                    HasBought = data.ProductClients.Any(pro => pro.ProductId == p.Id && pro.ClientId == userId)
                })
                .ToListAsync();

            return View(products);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddInputModel()
            {
                Categories = await GetCategory(),
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddInputModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategory();
                return View(model);
            }

            bool isValidDate = DateTime.TryParseExact(model.AddedOn, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validAddedOn);
            if (!isValidDate)
            {
                model.Categories = await GetCategory();
                return View(model);
            }

            var userId = GetUserId();
            if (userId == null) return RedirectToAction(nameof(Index));

            var category = await data.Categories.FindAsync(model.CategoryId);
            if (category == null)
            {
                model.Categories = await GetCategory();
                return View(model);
            }

            var user = await data.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                model.Categories = await GetCategory();
                return View(model);
            }

            var product = new Product
            {
                ProductName = model.ProductName,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                AddedOn = validAddedOn,
                CategoryId = model.CategoryId,
                Category = category,
                SellerId = userId,
                Seller = user,
                ProductsClients = new List<ProductClient>()
            };

            await data.Products.AddAsync(product);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var userId = GetUserId();
            var products = await data.Products
                .Where(p => p.ProductsClients.Any(pc => pc.ClientId == userId))
                .Select(p => new CartViewModel
                {
                    Id = p.Id.ToString(),
                    ImageUrl = p.ImageUrl ?? string.Empty,
                    ProductName = p.ProductName,
                    Price = p.Price
                })
                .ToListAsync();

            return View(products);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (!int.TryParse(id, out int validId)) return RedirectToAction(nameof(Index));

            var product = await data.Products.FirstOrDefaultAsync(p => p.Id == validId);

            if (product == null) return RedirectToAction(nameof(Index));

            var model = new EditViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl ?? string.Empty,
                AddedOn = product.AddedOn.ToString("dd-MM-yyyy"),
                CategoryId = product.CategoryId,
                SellerId = product.SellerId,
                Categories = await GetCategory()
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategory();
                return View(model);
            }

            if (!DateTime.TryParseExact(model.AddedOn, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validDate))
            {
                model.Categories = await GetCategory();
                return View(model);
            }

            var product = await data.Products.FindAsync(model.Id);

            if (product == null) return RedirectToAction(nameof(Index));

            product.ProductName = model.ProductName;
            product.Price = model.Price;
            product.Description = model.Description;
            product.ImageUrl = model.ImageUrl;
            product.AddedOn = validDate;
            product.CategoryId = model.CategoryId;

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Details));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart(string id)
        {
            if (!int.TryParse(id, out var productId)) return RedirectToAction(nameof(Index));

            var userId = GetUserId();
            if (userId == null) return RedirectToAction(nameof(Index));

            if (await data.ProductClients.AnyAsync(p => p.ClientId == userId && p.ProductId == productId)) return RedirectToAction(nameof(Index));

            var productClient = new ProductClient
            {
                ClientId = userId,
                ProductId = productId,
            };

            await data.ProductClients.AddAsync(productClient);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(string id)
        {
            if (!int.TryParse(id, out var productId)) return RedirectToAction(nameof(Index));

            var userId = GetUserId();
            if (userId == null) return RedirectToAction(nameof(Index));

            var productToRemove = await data.ProductClients.FirstOrDefaultAsync(p => p.ClientId == userId && p.ProductId == productId);

            if (productToRemove == null) return RedirectToAction(nameof(Index));

            data.ProductClients.Remove(productToRemove);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (!int.TryParse(id, out var productId)) return RedirectToAction(nameof(Index));

            var userId = GetUserId();

            var product = await data.Products
                .Include(p => p.Category)
                .Include(p => p.ProductsClients)
                .FirstOrDefaultAsync(p => p.Id == productId && !p.IsDeleted);

            if (product == null) return RedirectToAction(nameof(Index));

            var seller = await data.Users.FirstOrDefaultAsync(u => u.Id == product.SellerId);

            if (seller == null) return RedirectToAction(nameof(Index));
            var model = new DetailsViewModel
            {
                Id = productId,
                ImageUrl = product.ImageUrl ?? string.Empty,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                AddedOn = product.AddedOn.ToString(DateTimeFormat),
                Seller = seller.UserName , 
                HasBought = await data.ProductClients.AnyAsync(pro => pro.ProductId == productId && pro.ClientId == userId)
            };

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (!int.TryParse(id, out var productId)) return RedirectToAction(nameof(Index));

            var userId = GetUserId();

            var product = await data.Products
                .Include(p => p.Category)
                .Include(p => p.ProductsClients)
                .FirstOrDefaultAsync(p => p.Id == productId && !p.IsDeleted);

            if (product == null) return RedirectToAction(nameof(Index));

            var seller = await data.Users.FirstOrDefaultAsync(u => u.Id == product.SellerId);

            if (seller == null) return RedirectToAction(nameof(Index));

            var model = new DeleteViewModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                SellerId = product.SellerId,
                Seller = seller.UserName ?? string.Empty
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteViewModel model)
        {  
            var userId = GetUserId();

            var product = await data.Products
                .Include(p => p.ProductsClients)
                .FirstOrDefaultAsync(p => p.Id == model.Id && !p.IsDeleted);

            if (product == null) return RedirectToAction(nameof(Index));

            if (product.SellerId != userId) return Forbid();

            product.IsDeleted = true;

            data.ProductClients.RemoveRange(product.ProductsClients);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task<List<Category>> GetCategory()
        {
            return await data.Categories.ToListAsync();
        }
    }
}
