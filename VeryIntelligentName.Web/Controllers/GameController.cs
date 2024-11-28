using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VeryIntelligentName.Data;
using VeryIntelligentName.Data.Models;
using VeryIntelligentName.Services.Data;
using VeryIntelligentName.Web.Infrastructure.Extentions;

namespace VeryIntelligentName.Web.Controllers
{
    [Authorize]
    public class GameController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext, IDatabaseManager manager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            if (!this.IsDatabaseAvailable(dbContext, userManager, User)) return null;

            if (!Guid.TryParse(User.GetUserId(), out var guid)) return Unauthorized();


            return View();
        }
    }
}
