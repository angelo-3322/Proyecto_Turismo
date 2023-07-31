using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_Turismo.Application.Contracts.Repositories;

namespace Proyecto_Turismo.Persistence.Contexts.Repositories
{
    public static class RepositoryServicesCollectionExtension
    {
        public static IServiceCollection AddRepository<TEntity, TRepository>
            (this IServiceCollection services) 
            where TEntity : class
            where TRepository : class, IRepository<TEntity>
        {
            services.AddScoped<IRepository<TEntity>, TRepository>();
            return services;
        }

        public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services)
        where TContext : DbContext
        {
            services.AddScoped<IUnitOfWork<TContext>, UnitOfWork<TContext>>();
            return services;
        }
    }
}
