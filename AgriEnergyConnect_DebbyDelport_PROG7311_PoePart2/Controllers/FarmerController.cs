using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Data;
using AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Models;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Controllers
{
    [Authorize(Roles = "Farmer")]
    public class FarmerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FarmerController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null) return Unauthorized();

                model.FarmerID = user.Id; 
                _context.Products.Add(model);
                _context.SaveChanges();
                await _context.SaveChangesAsync();

                return RedirectToAction("MyProducts");
            }

            return View(model);
        }

        public async Task<IActionResult> MyProducts()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var products = await _context.Products
                .Where(p => p.FarmerID == user.Id) // FarmerID is now a string
                .ToListAsync();

            return View(products);
        }
    }
}
