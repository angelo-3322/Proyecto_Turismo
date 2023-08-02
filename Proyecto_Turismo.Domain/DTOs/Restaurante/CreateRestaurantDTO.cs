using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Restaurante
{
    public class CreateRestaurantDTO
    {
        public CreateRestaurantDTO() { }

        [Required]
        public int IdReservacion { get; private set; }

        [Required]
        public DateTime Fecha { get; private set; }

        [Required]
        public float Monto { get; private set; }
    }
}
