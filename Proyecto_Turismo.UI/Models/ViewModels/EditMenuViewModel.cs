using System.ComponentModel.DataAnnotations;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class EditMenuViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Nombre { get; set; }
    }
}
