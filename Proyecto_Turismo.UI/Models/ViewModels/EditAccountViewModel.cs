using System.ComponentModel.DataAnnotations;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class EditAccountViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Usuario { get;  set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Contrasena { get;  set; }
    }
}
