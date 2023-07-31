using Proyecto_Turismo.Domain.DTOs.Facturas;
using Proyecto_Turismo.Domain.DTOs.Reservaciones;
using Proyecto_Turismo.Domain.DTOs.Restaurante;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class CreateRestaurantViewModel
    {
        public CreateRestaurantViewModel()
        {
            Restaurants = new CreateRestaurantDTO();
            Reservations = new List<ListReservationDTO>();
        }

        public List<ListReservationDTO> Reservations { get; set; }

        public CreateRestaurantDTO Restaurants { get; set; }
    }
}
