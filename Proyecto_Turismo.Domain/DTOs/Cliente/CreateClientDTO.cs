using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Cliente
{
    public class CreateClienteDTO
    {
        public CreateClienteDTO() { }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Nombre { get; private set; }

        [Required, EmailAddress]
        [StringLength(30, MinimumLength = 10)]
        public string Email { get; private set; }

        [Required]
        public int Telefono { get; private set; }
    }
}
