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

        public ListReservationDTO(int id,int idhabitaciones, int idpaquete, int idcliente, DateTime fechainicio, DateTime fechafin, bool activo)
        {
            Id = id;
            IdHabitaciones = idhabitaciones;
            IdPaquete = idpaquete;
            IdCliente = idcliente;
            FechaInicio = fechainicio;
            FechaFin = fechafin;
            Activa = activo;
        } 

        public int Id { get;  set; }

        [ForeignKey("Habitacion")]
        public int IdHabitaciones { get;  set; }

        [ForeignKey("Paquete")]
        public int IdPaquete { get;  set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get;  set; }
        public DateTime FechaInicio { get;  set; }
        public DateTime FechaFin { get;  set; }
        public bool Activa { get;  set; }
    }
}
