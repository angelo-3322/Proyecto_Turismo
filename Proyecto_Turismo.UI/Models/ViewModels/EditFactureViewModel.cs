using System.ComponentModel.DataAnnotations;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class EditFactureViewModel
    {

        [Required]
        public DateTime FechaEmision { get;  set; }

        [Required]
        public float Monto { get;  set; }
    }
}
