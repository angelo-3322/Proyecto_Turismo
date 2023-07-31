using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Persistence.Contexts.Repositories
{
    public class RestauranteRepository : Repository<Restaurante>, IRestauranteRepository
    {
        public RestauranteRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
