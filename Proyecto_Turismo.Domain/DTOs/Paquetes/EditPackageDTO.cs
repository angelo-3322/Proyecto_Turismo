using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Paquetes
{
    public class EditPackageDTO
    {
        public EditPackageDTO() { }

        public EditPackageDTO(int id, string nombre, float precio)
            : this()
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Nombre { get; private set; }

        [Required]
        public float Precio { get; private set; }
    }
}
