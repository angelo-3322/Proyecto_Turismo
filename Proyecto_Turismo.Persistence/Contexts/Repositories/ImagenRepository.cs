using Microsoft.EntityFrameworkCore;
using Proyecto_Turismo.Application.Contracs.Repositories;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Persistence.Contexts.Repositories
{
    public class ImagenRepository : Repository<Imagen>, IImagenRepository
    {
        public ImagenRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {

        }
    }
}
