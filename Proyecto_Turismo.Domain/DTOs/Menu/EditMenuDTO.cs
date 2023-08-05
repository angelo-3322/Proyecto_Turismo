using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Menu
{
    public class EditMenuDTO
    {
        public EditMenuDTO() { }

        public EditMenuDTO(int id, string nombre)
            : this()
        {
            Id = id;
            Nombre = nombre;
        }
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Nombre { get; private set; }
    }
}
