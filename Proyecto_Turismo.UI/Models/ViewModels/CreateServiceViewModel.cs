using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Servicios;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class CreateServiceViewModel
    {
        public CreateServiceViewModel()
        {
            Services = new CreateServicesDTO();
        }


        public CreateServicesDTO Services { get; set; }
    }
}
