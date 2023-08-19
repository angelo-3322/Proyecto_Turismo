using System.ComponentModel.DataAnnotations;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class EditHotelRoomViewModel
    {
        public int Id { get; set; }

        [Required]
        public int NumeroHabitaciones { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string TipoHabitacion { get; set; }

        [Required]
        public int Capacidad { get; set; }

        [Required]
        public float Precio { get; set; }

        [Required]
        public bool Disponible { get; set; }

        public byte[] Imagen { get; set; }

        [Display(Name = "Imagen")]
        public IFormFile ImageFile { get; set; }

        public string ImageSrc { get; set; }
    }
}
