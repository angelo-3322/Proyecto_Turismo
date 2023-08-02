using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Reservaciones
{
    public class ListReservationDTO
    {
        public ListReservationDTO()
        {
            
        }

        public ListReservationDTO(int id, string fechainicio, string fechafin)
        {
            Id = id;
            FechaInicio = fechainicio;
            FechaFin = fechafin;
        }

        public int Id { get;  set; }


        public string FechaInicio { get;  set; }

        public string FechaFin { get;  set; }
    }
}
