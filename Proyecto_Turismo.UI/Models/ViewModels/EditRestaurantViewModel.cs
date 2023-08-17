using System.ComponentModel.DataAnnotations;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class EditRestaurantViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Nombre { get; set; }
    }
}
