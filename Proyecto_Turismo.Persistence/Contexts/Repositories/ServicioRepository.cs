using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Persistence.Contexts.Repositories
{
    public class ServicioRepository : Repository<Servicio>, IServicioRepository
    {
        public ServicioRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
