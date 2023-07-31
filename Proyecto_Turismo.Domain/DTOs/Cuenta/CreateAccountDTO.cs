using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Cuenta
{
    public class CreateAccountDTO
    {
        public CreateAccountDTO(){ }

        [Required]
        public int IdCliente { get;  set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Usuario { get;  set; }

        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string Contrasena { get;  set; }
    }
}
