using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VeryIntelligentName.Data;
using VeryIntelligentName.Data.Models;
using VeryIntelligentName.Web.ViewModels;

namespace VeryIntelligentName.Web.Controllers
{
    public class HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext applicationDbContext) : Controller
    {

        public IActionResult Index()
        {
            if (!this.IsDatabaseAvailable(applicationDbContext)) return Error();
            string userId = userManager.GetUserId(User)!;
            if (String.IsNullOrWhiteSpace(userId))
            {
                return Redirect("/Identity/Account/Login");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
