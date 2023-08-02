using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Paquetes
{
    public class CreatePackageDTO
    {
        public CreatePackageDTO() { }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Nombre { get; private set; }

        [Required]
        [StringLength(35, MinimumLength = 10)]
        public string Descripcion { get; private set; }

        [Required]
        public float precio { get; private set; }
    }
}
