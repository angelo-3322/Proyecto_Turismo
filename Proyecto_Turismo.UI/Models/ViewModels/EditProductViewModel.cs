using System.ComponentModel.DataAnnotations;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class EditProductViewModel
    {
        [Required]
        [StringLength(25, MinimumLength = 5)]
        public string Nombre { get; set; }

        [StringLength(30, MinimumLength = 7)]
        public string Descripcion { get; set; }

        [Required]
        public float Precio { get; set; }
    }
}
