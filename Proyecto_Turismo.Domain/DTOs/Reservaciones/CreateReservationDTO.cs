using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Turismo.Domain.DTOs.Reservaciones
{
    public class CreateReservationDTO
    {
        [Required]
        [ForeignKey("Habitacion")]
        public int IdHabitaciones { get;  set; }

        [Required]
        [ForeignKey("Paquete")]
        public int IdPaquete { get;  set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime FechaInicio { get;  set; }

        [Required]
        public DateTime FechaFin { get;  set; }

        [Required]
        public bool Activa { get;  set; }
    }
}
