using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VeryIntelligentName.Data;
using VeryIntelligentName.Services.Mapping;
using VeryIntelligentName.Web.ViewModels;
using VeryIntelligentName.Web.Infrastructure.Extentions;
using VeryIntelligentName.Data.Models;
using Microsoft.Data.SqlClient;

namespace VeryIntelligentName.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DBConnection") ?? throw new InvalidOperationException("Connection string 'DBConnection' not found.");

            builder.Services
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });

            builder.Services
                .AddIdentity<ApplicationUser, IdentityRole<Guid>>(builder.Configuration.ConfigureIdentity)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddRoles<IdentityRole<Guid>>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddUserManager<UserManager<ApplicationUser>>();

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/Identity/Account/Login";
            });

            //////////////builder.Services.RegisterRepositories(typeof(ApplicationUser).Assembly);
            //////////////builder.Services.RegisterUserDefinedServices(typeof(IMovieService).Assembly);

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            WebApplication app = builder.Build();

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Authorization can work only if we know who uses the application -> We need Authentication
            app.UseAuthentication(); // First -> Who am I?
            app.UseAuthorization(); // Second -> What can I do?

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            app.MapRazorPages(); // Add routing to Identity Razor Pages

            app.ApplyMigrations();

            app.Run();
        }
    }
}
