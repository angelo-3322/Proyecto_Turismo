using Microsoft.EntityFrameworkCore;
using Proyecto_Turismo.Application.Contracts.Contexts;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Persistence.Contexts
{ 
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Reservacion> Reservaciones { get; set; }
        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }



        public void Save()
        {
            this.SaveChanges();
        }
    }
}
