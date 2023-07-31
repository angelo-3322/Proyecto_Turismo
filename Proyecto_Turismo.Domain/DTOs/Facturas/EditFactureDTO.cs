using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.DTOs.Facturas
{
    public class EditFactureDTO
    {
        public EditFactureDTO()
        {
            
        }

        public EditFactureDTO(int id, DateTime fechaEmision, float monto)
        {
            Id = id;
            FechaEmision = fechaEmision;
            Monto = monto;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime FechaEmision { get; private set; }

        [Required]
        public float Monto { get; private set; }
    }
}
