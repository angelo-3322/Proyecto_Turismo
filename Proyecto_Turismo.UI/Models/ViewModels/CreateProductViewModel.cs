using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Menu;
using Proyecto_Turismo.Domain.DTOs.Producto;
using Proyecto_Turismo.Domain.DTOs.Reservaciones;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class CreateProductViewModel
    {
        public CreateProductViewModel()
        {
            Products = new CreateProductoDTO();
            Menus = new List<ListMenuDTO>();
        }

        public List<ListMenuDTO> Menus { get; set; }
        public CreateProductoDTO Products{ get; set; }
    }
}
