using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Reservaciones
{
    public class EditReservationDTO
    {

        [Required]
        public DateTime FechaInicio { get; private set; }

        [Required]
        public DateTime FechaFin { get; private set; }
    }
}
