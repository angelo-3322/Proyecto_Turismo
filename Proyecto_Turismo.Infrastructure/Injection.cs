using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_Turismo.Application.Contracs.Identity;
using Proyecto_Turismo.Infrastructure.Contexts;
using Proyecto_Turismo.Infrastructure.Identity;

namespace Proyecto_Turismo.Infrastructure
{
    public static class Injection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 3;

            }).AddEntityFrameworkStores<ApplicationIdentityDbContext>();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
            });

            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
