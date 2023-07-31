using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Persistence.Contexts.Repositories
{
    public class CuentaRepository : Repository<Cuenta>, ICuentaRepository
    {
        public CuentaRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
