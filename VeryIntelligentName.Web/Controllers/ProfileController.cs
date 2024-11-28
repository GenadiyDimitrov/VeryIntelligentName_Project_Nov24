using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Globalization;
using VeryIntelligentName.Data;
using VeryIntelligentName.Data.Models;
using VeryIntelligentName.Services.Data;
using VeryIntelligentName.Web.Infrastructure.Extentions;
using VeryIntelligentName.Web.ViewModels;

namespace VeryIntelligentName.Web.Controllers
{
    [Authorize]
    public class ProfileController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext, IDatabaseManager manager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            if (!this.IsDatabaseAvailable(dbContext, userManager, User)) return null;

            if (!Guid.TryParse(User.GetUserId(), out var guid)) return Unauthorized();

            List<Character> characters = await dbContext.Characters
                .Where(pc => pc.PlayerId == guid)
                .AsNoTracking()
                .ToListAsync();

            return View(new PlayerProfileViewModel() { Characters = characters });
        }

        public async Task<IActionResult> Settings()
        {
            if (!this.IsDatabaseAvailable(dbContext, userManager, User)) return null;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateChar()
        {
            if (!this.IsDatabaseAvailable(dbContext, userManager, User)) return null;
            var model = new CharAddViewModel()
            {
                Classes = await dbContext.CharacterClasses
                .AsNoTracking()
                .ToArrayAsync(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChar(CharAddViewModel model)
        {
            if (!Guid.TryParse(User.GetUserId(), out var guid)) return Unauthorized();

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(CreateChar));
            }
            IEnumerable<string>? charNames = await dbContext.Characters
            .AsNoTracking()
            .Select(s => s.Name)
            .ToArrayAsync();
            if (charNames != null && charNames.Contains(model.Name))
            {
                ModelState.AddModelError(nameof(model.Name), "Already added");
                return RedirectToAction(nameof(CreateChar));
            }
            model.Class = await dbContext.CharacterClasses
                 .FirstOrDefaultAsync(c => c.Id == model.ClassId);
            if (model.Class == null)
                return RedirectToAction(nameof(CreateChar));

            await manager.AddNewCharacter(guid, model);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid? selectedId)
        {
            if (selectedId == null) return RedirectToAction(nameof(Index));
            var item = dbContext.Characters.Find(selectedId);
            if (item == null) return NotFound();
            // Verify the user's authorization to delete this item
            if (!Guid.TryParse(User.GetUserId(), out var guid)) return Unauthorized();
            if (item.PlayerId != guid) return Unauthorized();

            // Perform the delete operation
            dbContext.Characters.Remove(item);
            await dbContext.SaveChangesAsync();

            // Redirect to the same page or another page
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Edit(Guid? selectedId)
        {
            if (selectedId == null) return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Index));
        }
    }
}
