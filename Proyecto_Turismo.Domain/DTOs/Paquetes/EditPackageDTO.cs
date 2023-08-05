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

        public EditPackageDTO(int id, string nombre, float precio,string descripcion)
            : this()
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Descripcion = descripcion;
        }

        public int Id { get; private set; }

        [Required]
        [StringLength(30, MinimumLength = 10)]
        public string Nombre { get; private set; }

        [Required]
        [StringLength(35, MinimumLength = 10)]
        public string Descripcion { get; private set; }

        [Required]
        public float Precio { get; private set; }
    }
}
