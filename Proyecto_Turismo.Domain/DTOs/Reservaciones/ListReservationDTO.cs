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

        public ListReservationDTO(int id, string userid, int habitacion, string paquete, DateTime fechainicio, DateTime fechafin, bool activo)
        {
            Id = id;
            Habitacion = habitacion;
            Paquete = paquete;
            UserId = userid;
            FechaInicio = fechainicio;
            FechaFin = fechafin;
            Activa = activo;
        } 

        public int Id { get;  set; }

        public int Habitacion { get;  set; }
        public string Paquete { get;  set; }
        public string UserId { get; set; }
        public DateTime FechaInicio { get;  set; }
        public DateTime FechaFin { get;  set; }
        public bool Activa { get;  set; }
    }
}
