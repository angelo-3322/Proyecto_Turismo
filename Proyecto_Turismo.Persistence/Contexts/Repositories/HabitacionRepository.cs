using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Persistence.Contexts.Repositories
{
    public class HabitacionRepository : Repository<Habitacion>, IHabitacionRepository
    {
        public HabitacionRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
