using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Persistence.Contexts.Repositories
{
    public class ReservacionRepository : Repository<Reservacion>, IReservacionRepository
    {
        public ReservacionRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
