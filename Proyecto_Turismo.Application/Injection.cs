using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Services;

namespace Proyecto_Turismo.Application
{
    public static class Injection
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFacturaService, FacturaService>();
            services.AddScoped<IHabitacionService, HabitacionService>();
            services.AddScoped<IPaqueteService, PaqueteService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IReservacionService, ReservacionService>();
            services.AddScoped<IRestauranteService, RestauranteService>();

            return services;
        }
    }
}
