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
        [StringLength(30, MinimumLength = 10)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 10)]
        public string Descripcion { get; set; }

        [Required]
        public float Precio { get; set; }

    }
}
