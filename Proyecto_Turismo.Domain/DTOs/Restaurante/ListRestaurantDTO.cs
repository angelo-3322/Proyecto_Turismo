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
    public class ListRestaurantDTO
    {
        public ListRestaurantDTO(){}

        public ListRestaurantDTO(int id, string nombre, int idmenu)
        {
            Id = id;
            Nombre = nombre;
            IdMenu = idmenu;
        }

        public int Id { get;  set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Nombre { get; set; }

        [ForeignKey("Menu")]
        public int IdMenu { get; set; }


    }
}
