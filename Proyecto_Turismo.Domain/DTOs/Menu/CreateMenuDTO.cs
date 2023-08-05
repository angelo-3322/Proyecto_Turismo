using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Menu
{
    public class CreateMenuDTO
    {
        public CreateMenuDTO() { }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Nombre { get; set; }
    }
}
