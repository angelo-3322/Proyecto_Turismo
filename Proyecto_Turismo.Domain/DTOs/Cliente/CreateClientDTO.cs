using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Cliente
{
    public class CreateClientDTO
    {
        public CreateClientDTO() { }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Nombre { get;  set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Email { get;  set; }

        [Required]
        public int Telefono { get;  set; }
    }
}
