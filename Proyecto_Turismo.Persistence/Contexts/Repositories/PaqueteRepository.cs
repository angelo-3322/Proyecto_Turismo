using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Persistence.Contexts.Repositories
{
    public class PaqueteRepository : Repository<Paquete>, IPaqueteRepository
    {
        public PaqueteRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
