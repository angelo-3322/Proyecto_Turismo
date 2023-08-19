using Proyecto_Turismo.Domain.DTOs.Menu;
using Proyecto_Turismo.Domain.DTOs.Producto;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class EditProductViewModel
    {
        public EditProductViewModel()
        {
            Menus = new List<ListMenuDTO>();
        }

        public EditProductoDTO Product { get; set; }
        public List<ListMenuDTO> Menus { get; set; }
    }
}

