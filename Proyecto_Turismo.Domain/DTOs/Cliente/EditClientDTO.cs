using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Cliente
{
    public class EditClientDTO
    {
        public EditClientDTO() { }

        public EditClientDTO(int id, string nombre, string email, int telefono)
            : this()
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
        }
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Nombre { get; private set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Email { get; private set; }

        [Required]
        public int Telefono { get; private set; }
    }
}
