using System.ComponentModel.DataAnnotations;


namespace Proyecto_Turismo.Domain.DTOs.Habitaciones
{
    public class CreateHotelRoomDTO
    {
        [Required]
        public int NumeroHabitaciones { get;  set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string TipoHabitacion { get;  set; }

        [Required]
        public int Capacidad { get;  set; }

        [Required]
        public float Precio { get;  set; }

        [Required]
        public bool Disponible { get;  set; }

        public List<byte[]> Imagenes { get; set; } = new List<byte[]>();
    }
}
