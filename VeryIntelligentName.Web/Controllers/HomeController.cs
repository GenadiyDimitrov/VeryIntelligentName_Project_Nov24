using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (!this.IsDatabaseAvailable(applicationDbContext, userManager, User)) return Error();
            string userId = userManager.GetUserId(User)!;
            if (String.IsNullOrWhiteSpace(userId))
            {
                return Redirect("/Identity/Account/Login");
            }
            return Redirect(Url.Action("Index", "Profile"));
        }

        public async Task<IActionResult> About()
        {
            var classes = await applicationDbContext.CharacterClasses
                .AsNoTracking()
                .ToArrayAsync();
            return View(classes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
