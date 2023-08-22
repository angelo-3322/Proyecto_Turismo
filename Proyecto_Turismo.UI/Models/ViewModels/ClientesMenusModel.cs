using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_Turismo.Domain.DTOs.Producto;
using Proyecto_Turismo.Domain.DTOs.Restaurante;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class ClientesMenusModel
    {
        public int MenuId { get; set; } 
        public List<SelectListItem> Menus { get; set; }
        public List<ListRestaurantDTO> Restaurante { get; set; }
        public List<ListProductoDTO> Productos { get; set; }
    }
}
