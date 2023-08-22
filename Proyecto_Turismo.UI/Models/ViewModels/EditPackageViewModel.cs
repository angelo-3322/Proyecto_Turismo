using System.ComponentModel.DataAnnotations;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class EditPackageViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Nombre { get;  set; }

        [Required]
        [StringLength(35, MinimumLength = 5)]
        public string Descripcion { get; set; }

        [Required]
        public float Precio { get;  set; } 
    }
}
