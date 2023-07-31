using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Reservaciones
{
    public class CreateReservationDTO
    {
        [Required]
        public int IdHabitaciones { get; private set; }


        [Required]
        public int IdPaquete { get; private set; }

        [Required]
        public int IdCliente { get; private set; }

        [Required]
        public DateTime FechaInicio { get; private set; }

        [Required]
        public DateTime FechaFin { get; private set; }
    }
}
