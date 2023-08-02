using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Restaurante
{
    public class ListRestaurantDTO
    {
        public ListRestaurantDTO(){}

        public ListRestaurantDTO(int id, string reservacion, string fecha, float monto)
        {
            Id = id;
            Reservacion = reservacion;
            Fecha = fecha; 
            Monto = monto;
        }

        public int Id { get;  set; }


        public string Reservacion { get;  set; }


        public string Fecha { get;  set; }


        public float Monto { get;  set; }
    }
}
