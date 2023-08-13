using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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

        public static Factura Create(int idreservacion, float monto)
        {
            return
                new Factura()
                {
                    IdReservacion = idreservacion,
                    FechaEmision = DateTime.Now,
                    Monto = monto
                };
        }

        public void Update(DateTime fechaEmision, float monto)
        {
            FechaEmision = fechaEmision;
            Monto = monto;

        }
    }
}
