using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_Turismo.Application.Contracs.Repositories;
using Proyecto_Turismo.Application.Contracts.Contexts;
using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.Entities;
using Proyecto_Turismo.Persistence.Contexts;
using Proyecto_Turismo.Persistence.Contexts.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Persistence
{
    public static class Injection
    {
        public static IServiceCollection AddPersistenceServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IApplicationDbContext>
                (options => options.GetService<ApplicationDbContext>());

            services.AddUnitOfWork<ApplicationDbContext>()
                .AddRepository<Cliente, ClienteRepository>();

            services.AddUnitOfWork<ApplicationDbContext>()
                .AddRepository<Factura, FacturaRepository>();

            services.AddUnitOfWork<ApplicationDbContext>()
                .AddRepository<Habitacion, HabitacionRepository>();

            services.AddUnitOfWork<ApplicationDbContext>()
                .AddRepository<Paquete, PaqueteRepository>();

            services.AddUnitOfWork<ApplicationDbContext>()
                .AddRepository<Reservacion, ReservacionRepository>();

            services.AddUnitOfWork<ApplicationDbContext>()
                .AddRepository<Restaurante, RestauranteRepository>();

            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IFacturaRepository, FacturaRepository>();

            services.AddScoped<IHabitacionRepository, HabitacionRepository>();

            services.AddScoped<IPaqueteRepository, PaqueteRepository>();

            services.AddScoped<IMenuRepository, MenuRepository>();

            services.AddScoped<IProductoRepository, ProductoRepository>();

            services.AddScoped<IReservacionRepository, ReservacionRepository>();

            services.AddScoped<IRestauranteRepository, RestauranteRepository>();

            return services;
        }
    }
}
