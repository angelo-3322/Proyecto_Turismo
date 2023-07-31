using Microsoft.EntityFrameworkCore;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Application.Contracts.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Cliente> Clientes { get; set;  }
        DbSet<Cuenta> Cuentas { get; set;  }
        DbSet<Factura> Facturas { get; set;  }
        DbSet<Habitacion> Habitaciones { get; set;  }
        DbSet<Paquete> Paquetes { get; set;  }
        DbSet<Reservacion> Reservaciones { get; set;  }
        DbSet<Restaurante> Restaurante { get; set;  }
        DbSet<Servicio> Servicios { get; set;  }

        void Save();
    }
}
