using Microsoft.AspNetCore.Identity;

namespace VeryIntelligentName.Web
{
    public static class Extentions
    {
        public static void ConfigureIdentity(this ConfigurationManager configuration, IdentityOptions cfg)
        {
            cfg.Password.RequireDigit =
                configuration.GetValue<bool>("Identity:Password:RequireDigits");
            cfg.Password.RequireLowercase =
                configuration.GetValue<bool>("Identity:Password:RequireLowercase");
            cfg.Password.RequireUppercase =
                configuration.GetValue<bool>("Identity:Password:RequireUppercase");
            cfg.Password.RequireNonAlphanumeric =
                configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumerical");
            cfg.Password.RequiredLength =
                configuration.GetValue<int>("Identity:Password:RequiredLength");
            cfg.Password.RequiredUniqueChars =
                configuration.GetValue<int>("Identity:Password:RequiredUniqueCharacters");

            cfg.SignIn.RequireConfirmedAccount =
                configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
            cfg.SignIn.RequireConfirmedEmail =
                configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedEmail");
            cfg.SignIn.RequireConfirmedPhoneNumber =
                configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedPhoneNumber");

            cfg.User.RequireUniqueEmail =
                configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");
        }
    }
}
