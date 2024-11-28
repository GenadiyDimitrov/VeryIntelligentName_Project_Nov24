using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VeryIntelligentName.Data;
using VeryIntelligentName.Data.Models;

namespace VeryIntelligentName.Web
{
    public static class DatabaseExtention
    {
        public static bool IsDatabaseAvailable(this Controller controller,DbContext dbContext, UserManager<ApplicationUser> userManager,ClaimsPrincipal User)
        {
            if (dbContext.Database.CanConnect())
            {
                string userId = userManager.GetUserId(User)!;
                if (String.IsNullOrWhiteSpace(userId))
                {
                    controller.Redirect("/Identity/Account/Login");
                }
                return true;
            }
            controller.Redirect("Home/Error");
            return false;
        }
    }
}
