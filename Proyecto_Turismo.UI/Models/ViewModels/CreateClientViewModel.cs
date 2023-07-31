using Proyecto_Turismo.Domain.DTOs.Cliente;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class CreateClientViewModel
    {
        public CreateClientViewModel()
        {
            Clients = new CreateClientDTO();
        }


        public CreateClientDTO Clients { get; set; }
    }
}
