using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_Turismo.Domain.DTOs.Menu;
using Proyecto_Turismo.Domain.DTOs.Restaurante;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class EditRestaurantViewModel
    {
        public EditRestaurantViewModel()
        {
            Menus = new List<ListMenuDTO>();
        }

        public EditRestaurantDTO Restaurante { get; set; }
        public List<ListMenuDTO> Menus { get; set; }
    }
}
