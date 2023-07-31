using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Facturas
{
    public class CreateFactureDTO
    {
        public CreateFactureDTO() {}

        [Required]
        public int IdReservaciones { get;  set; }

        [Required]
        public DateTime FechaEmision { get;  set; }

        [Required]
        public float Monto { get;  set; }
    }
}
