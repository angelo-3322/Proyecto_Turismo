using Microsoft.EntityFrameworkCore;
using Proyecto_Turismo.Application.Contracs.Repositories;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Persistence.Contexts.Repositories
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
