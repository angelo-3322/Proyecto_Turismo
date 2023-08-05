using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Habitaciones;
using Proyecto_Turismo.Domain.DTOs.Paquetes;
using Proyecto_Turismo.Domain.DTOs.Reservaciones;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class CreateReservationViewModel
    {
        public CreateReservationViewModel()
        {
            Reservations = new CreateReservationDTO();
            Rooms = new List<ListHotelRoomDTO>();
            Packages = new List<ListPackageDTO>();
            Clients = new List<ListClienteDTO>();
        }

        public List<ListHotelRoomDTO> Rooms { get; set; }
        public List<ListPackageDTO> Packages { get; set; }
        public List<ListClienteDTO> Clients { get; set; }

        public CreateReservationDTO Reservations { get; set; }
    }
}
