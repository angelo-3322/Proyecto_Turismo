﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Application.Contracts.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Factura> Facturas { get; set;  }
        DbSet<Habitacion> Habitaciones { get; set;  }
        DbSet<Paquete> Paquetes { get; set;  }
        DbSet<Reservacion> Reservaciones { get; set;  }
        DbSet<Restaurante> Restaurante { get; set;  }
        DbSet<Menu> Menus { get; set; }
        DbSet<Producto> Productos { get; set; }





        void Save();
    }
}
