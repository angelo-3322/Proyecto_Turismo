using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Domain.DTOs.Reservaciones
{
    public class EditReservationDTO
    {
        public EditReservationDTO() { } 

        public EditReservationDTO(int idhabitaciones, int idpaquete, int idcliente, DateTime fechainicio, DateTime fechafin, bool activo)
            : this()
        {

            IdHabitaciones = idhabitaciones;
            IdPaquete = idpaquete;
            IdCliente = idcliente;
            FechaInicio = fechainicio;
            FechaFin = fechafin;
            Activa = activo;
        }

        public int Id { get; private set; }

        [Required]
        [ForeignKey("Habitacion")]
        public int IdHabitaciones { get;  set; }


        [Required]
        [ForeignKey("Paquete")]
        public int IdPaquete { get;  set; }


        [Required]
        [ForeignKey("Cliente")]
        public int IdCliente { get;  set; }

        [Required]
        public DateTime FechaInicio { get;  set; }

        [Required]
        public DateTime FechaFin { get;  set; }

        [Required]
        public bool Activa { get;  set; }
    }
}
