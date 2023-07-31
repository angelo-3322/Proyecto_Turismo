using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Proyecto_Turismo.Domain.Entities
{
    public class Cliente
    {
        public Cliente() { }

        [Key]
        public int Id { get; private set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Nombre { get; private set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Email { get; private set; }

        [Required]
        public int Telefono { get; private set; }

        public static Cliente Create(string nombre, string email, int telefono)
        {
            return
                new Cliente()
                {
                    Nombre = nombre,
                    Email = email,
                    Telefono = telefono
                };
        }
    }
}
