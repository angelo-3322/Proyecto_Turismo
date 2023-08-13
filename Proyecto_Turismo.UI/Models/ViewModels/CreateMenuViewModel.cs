using Proyecto_Turismo.Domain.DTOs.Menu;
using Proyecto_Turismo.Domain.DTOs.Producto;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class CreateMenuViewModel
    {
        public CreateMenuViewModel()
        {
            Menus = new CreateMenuDTO();
        }

        public CreateMenuDTO Menus { get; set; }
    }
}
