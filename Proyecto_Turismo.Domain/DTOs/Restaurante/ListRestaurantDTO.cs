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

        public ListRestaurantDTO(int id, string menu, string nombre)
        {
            Id = id;
            Nombre = nombre;
            Menu = menu;
        }

        public int Id { get;  set; }

        public string Menu { get; set; }

        public string Nombre { get; set; }

        


    }
}
