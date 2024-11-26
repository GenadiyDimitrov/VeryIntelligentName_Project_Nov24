using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeryIntelligentName.Data;

namespace VeryIntelligentName.Web
{
    public static class DatabaseExtention
    {
        public static bool IsDatabaseAvailable(this Controller controller,DbContext dbContext)
        {
            return dbContext.Database.CanConnect();
        }
    }
}
