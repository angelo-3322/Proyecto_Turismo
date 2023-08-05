using Microsoft.EntityFrameworkCore;
using Proyecto_Turismo.Application.Contracs.Repositories;
using Proyecto_Turismo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Persistence.Contexts.Repositories
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
