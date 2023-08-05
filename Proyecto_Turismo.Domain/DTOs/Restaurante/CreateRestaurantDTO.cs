using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Domain.DTOs.Restaurante
{
    public class CreateRestaurantDTO
    {
        public CreateRestaurantDTO() { }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Nombre { get;  set; }

        [ForeignKey("Menu")]
        public int IdMenu { get;  set; }
    }
}
