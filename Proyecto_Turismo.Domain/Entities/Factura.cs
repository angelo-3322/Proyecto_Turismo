using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.Entities
{
    public class Factura
    {
        public Factura() { }

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Reservacion")]
        public int IdReservacion { get; private set; }

        public Reservacion Reservacion { get; private set; }

        [Required]
        public DateTime FechaEmision { get; private set; }

        [Required]
        public float Monto { get; private set; }

        public static Factura Create(int idreservacion, DateTime fechaemision, float monto)
        {
            return
                new Factura()
                {
                    IdReservacion = idreservacion,
                    FechaEmision = fechaemision,
                    Monto = monto
                };
        }
    }
}
