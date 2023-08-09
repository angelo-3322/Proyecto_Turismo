using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto_Turismo.Application.Contracs.Contexts;
using Proyecto_Turismo.Application.Contracts.Contexts;

namespace Proyecto_Turismo.Infrastructure.Contexts
{
    public class ApplicationIdentityDbContext : IdentityDbContext<IdentityUser>, IApplicationIdentityDbContext
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
            : base(options)
        {
            
        }
    }
}
