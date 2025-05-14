using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Models;
using AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Data;
using UserRole = AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Models.UserRole;

namespace AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /Account/Register
        public IActionResult Register() => View();

        // POST: /Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(Models.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Assign role based on user selection
                    var role = model.UserRole == UserRole.Employee ? "Employee" : "Farmer";
                    await _userManager.AddToRoleAsync(user, role);

                    // Redirect to Login
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        // GET: /Account/Login
        public IActionResult Login() => View();

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Find the user by email
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            // Check the password
            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            // Get the user's roles
            var roles = await _userManager.GetRolesAsync(user);

            // Redirect based on the user's role
            if (roles.Contains("Employee"))
            {
                return RedirectToAction("Dashboard", "Employee");
            }
            else if (roles.Contains("Farmer"))
            {
                return RedirectToAction("Dashboard", "Farmer");
            }

            // Default fallback
            return RedirectToAction("Index", "Home");
        }

        // POST: /Account/Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
