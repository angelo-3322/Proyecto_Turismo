using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Cuenta;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class CreateAccountViewModel
    {
        public CreateAccountViewModel()
        {
            Accounts = new CreateAccountDTO();
            Clients = new List<ListClientDTO>();
        }

        public List<ListClientDTO> Clients { get; set; }

        public CreateAccountDTO Accounts { get; set; }
    }
}
