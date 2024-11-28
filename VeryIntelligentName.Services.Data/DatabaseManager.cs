using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeryIntelligentName.Data;
using VeryIntelligentName.Web.ViewModels;

namespace VeryIntelligentName.Services.Data
{
    public interface IDatabaseManager
    {
        public Task AddNewCharacter(Guid userId, CharAddViewModel model);
    }
    public class DatabaseManager(ApplicationDbContext context) : IDatabaseManager
    {
        public async Task AddNewCharacter(Guid userId, CharAddViewModel model)
        {
            await context.Characters.AddAsync(new()
            {
                Name = model.Name,
                ClassName = model.Class.ClassName,
                ATK = model.Class.ATK,
                CON = model.Class.CON,
                DEX = model.Class.DEX,
                InitiativeModifier = model.Class.InitiativeModifier,
                AtkModifier = model.Class.AtkModifier,
                DexModifier = model.Class.DexModifier,
                ConModifier = model.Class.ConModifier,
                Level = 1,
                PlayerId = userId,
            });
            await context.SaveChangesAsync();
        }
    }
}
