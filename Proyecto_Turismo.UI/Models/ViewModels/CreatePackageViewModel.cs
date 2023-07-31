using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Paquetes;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class CreatePackageViewModel
    {
        public CreatePackageViewModel()
        {
            Packages = new CreatePackageDTO();
        }


        public CreatePackageDTO Packages { get; set; }
    }
}
