using System.ComponentModel.DataAnnotations;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class EditClientViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Nombre { get;  set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Email { get;  set; }

        [Required]
        public int Telefono { get;  set; }
    }
}
