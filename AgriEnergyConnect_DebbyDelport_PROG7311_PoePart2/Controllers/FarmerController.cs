using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Data;
using AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Models;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Controllers
{
    // Restricts access to users in the "Farmer" role
    [Authorize(Roles = "Farmer")]
    public class FarmerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        // Constructor injects the database context and user manager
        public FarmerController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Displays the farmer dashboard view
        public IActionResult Dashboard()
        {
            return View();
        }

        // Returns the AddProduct view for GET requests
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        // Handles POST requests to add a new product for the current farmer
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                // Get the currently logged-in user
                var user = await _userManager.GetUserAsync(User);
                if (user == null) return Unauthorized();

                // Assign the current user's ID as the FarmerID
                model.FarmerID = user.Id; 
                _context.Products.Add(model);
                _context.SaveChanges();
                await _context.SaveChangesAsync();

                return RedirectToAction("MyProducts");
            }

            return View(model);
        }

        // Displays a list of products belonging to the current farmer
        public async Task<IActionResult> MyProducts()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            // Query products where the FarmerID matches the current user's ID
            var products = await _context.Products
                .Where(p => p.FarmerID == user.Id) 
                .ToListAsync();

            return View(products);
        }
    }
}
