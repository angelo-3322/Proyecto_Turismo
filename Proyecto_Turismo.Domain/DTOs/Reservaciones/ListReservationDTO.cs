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

        public ListReservationDTO(int id, int idhabitaciones, int idpaquete, int idcliente, string fechainicio, string fechafin)
        {
            Id = id;
            IdHabitaciones = idhabitaciones;
            IdPaquete = idpaquete;
            IdCliente = idcliente;
            FechaInicio = fechainicio;
            FechaFin = fechafin;
        }

        public int Id { get;  set; }

        public int IdHabitaciones { get;  set; }

        public int IdPaquete { get;  set; }

        public int IdCliente { get;  set; }

        public string FechaInicio { get;  set; }

        public string FechaFin { get;  set; }
    }
}
