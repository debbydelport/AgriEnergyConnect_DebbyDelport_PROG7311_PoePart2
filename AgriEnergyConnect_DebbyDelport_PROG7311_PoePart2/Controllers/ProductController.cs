using AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Models
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product); // Add the product to the database context
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction("MyProducts"); // Redirect to the MyProducts page
            }
            return View(product); // Return the view with validation errors if the model is invalid
        }

        // GET: /Product/MyProducts
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> MyProducts()
        {
            var products = await _context.Products.ToListAsync(); // Retrieve all products from the database
            return View(products); // Pass the list of products to the view
        }
    }
}
