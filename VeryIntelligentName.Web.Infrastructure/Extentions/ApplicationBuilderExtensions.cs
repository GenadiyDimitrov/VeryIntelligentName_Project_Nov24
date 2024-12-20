﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VeryIntelligentName.Data;
using VeryIntelligentName.Web.Infrastructure;

namespace VeryIntelligentName.Web.Infrastructure.Extentions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

            ApplicationDbContext dbContext = serviceScope
                .ServiceProvider
                .GetRequiredService<ApplicationDbContext>()!;
            try
            {
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
            }
            return app;
        }
    }
}
