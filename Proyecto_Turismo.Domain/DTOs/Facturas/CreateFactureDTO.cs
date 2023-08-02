using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Domain.DTOs.Facturas
{
    public class CreateFactureDTO
    {
        public CreateFactureDTO() 
        {
            FechaEmision = DateTime.Now;
        }

        [Required]
        [ForeignKey("Reservacion")]
        public int IdReservacion { get; set; }

        [Required]
        public DateTime FechaEmision { get; set; }

        [Required]
        public float Monto { get;  set; }
    }
}
