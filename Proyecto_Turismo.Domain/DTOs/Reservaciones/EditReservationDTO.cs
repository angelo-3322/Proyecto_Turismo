using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Domain.DTOs.Reservaciones
{
    public class EditReservationDTO
    {
        public EditReservationDTO() { }

        public EditReservationDTO(int id, DateTime fechainicio, DateTime fechafin, bool activo)
            : this()
        {

            FechaInicio = fechainicio;
            FechaFin = fechafin;
            Activa = activo;
        }

        public int Id { get; private set; }


        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [Required]
        public bool Activa { get; set; }
    }
}
