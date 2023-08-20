using Proyecto_Turismo.Domain.DTOs.Producto;
using Proyecto_Turismo.Domain.DTOs.Restaurante;

namespace Proyecto_Turismo.UI.Models.ViewModels.AccountModels
{
    public class RestauranteViewModel
    {
        public ListRestaurantDTO Restaurante { get; set; }
        public string NombreMenu { get; set; }
    }
}
