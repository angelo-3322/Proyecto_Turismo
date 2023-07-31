using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Habitaciones
{
    public class CreateHotelRoomDTO
    {
        public CreateHotelRoomDTO(){ }

        [Required]
        public int NumeroHabitaciones { get; private set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string TipoHabitacion { get; private set; }

        [Required]
        public int Capacidad { get; private set; }

        [Required]
        public float Precio { get; private set; }
    }
}
