using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Facturas;
using Proyecto_Turismo.Domain.DTOs.Reservaciones;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class CreateFactureViewModel
    {
        public CreateFactureViewModel()
        {
            Facture= new CreateFactureDTO();
            Reservations = new List<ListReservationDTO>();
        }

        public List<ListReservationDTO> Reservations { get; set; }

        public CreateFactureDTO Facture { get; set; }
    }
}
