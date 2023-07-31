using System.ComponentModel.DataAnnotations;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class EditHotelRoomViewModel
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
    }
}
