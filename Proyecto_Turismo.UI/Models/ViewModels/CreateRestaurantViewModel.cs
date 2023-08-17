using Proyecto_Turismo.Domain.DTOs.Facturas;
using Proyecto_Turismo.Domain.DTOs.Menu;
using Proyecto_Turismo.Domain.DTOs.Reservaciones;
using Proyecto_Turismo.Domain.DTOs.Restaurante;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class CreateRestaurantViewModel
    {
        public CreateRestaurantViewModel()
        {
            Restaurants = new CreateRestaurantDTO();
            menus = new List<ListMenuDTO>();
        }

        public List<ListMenuDTO> menus { get; set; }

        public CreateRestaurantDTO Restaurants { get; set; }
    }
}
