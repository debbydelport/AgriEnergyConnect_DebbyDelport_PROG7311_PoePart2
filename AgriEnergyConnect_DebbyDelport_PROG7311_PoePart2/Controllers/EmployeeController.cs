using AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Data;
using AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context; // Define the DbContext

        // Constructor to inject the DbContext
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Employee")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles = "Employee")]
        public IActionResult AddFarmer()
        {
            return View(); // form to add a farmer
        }

        [Authorize(Roles = "Employee")]
        [HttpPost]
        public IActionResult AddFarmer(Farmer model)
        {
            if (ModelState.IsValid)
            {
                // Save farmer
            }
            return RedirectToAction("Dashboard");
        }

        [Authorize(Roles = "Employee")]
        public IActionResult FilterProducts(string category, DateTime? from, DateTime? to)
        {
            // Filter logic
            return View();
        }

        public async Task<IActionResult> ViewFarmers()
        {
            // Fetch the list of farmers from the database
            List<Farmer> farmers = await _context.Farmers.ToListAsync();
            return View(farmers); // Pass the list to the view
        }


        public IActionResult Index()
        {
            return View();
        }

    }
}
