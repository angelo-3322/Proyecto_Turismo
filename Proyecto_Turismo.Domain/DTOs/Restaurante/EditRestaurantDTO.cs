using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Restaurante
{
    public class EditRestaurantDTO
    {
        public EditRestaurantDTO() { }

        public EditRestaurantDTO(int id, DateTime fecha, float monto)
            : this()
        {
            Id = id;
            Fecha = fecha;
            Monto = monto;
        }
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; private set; }

        [Required]
        public float Monto { get; private set; }
    }
}
