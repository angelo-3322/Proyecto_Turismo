using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Domain.Entities
{
    public class Restaurante
    {
        public Restaurante() { }

        [Key]
        public int Id { get; private set; }

        [Required]
        [ForeignKey("Reservaciones")]
        public int IdReservaciones { get; private set; }

        [Required]
        public DateTime Fecha { get; private set; }

        [Required]
        public float Monto { get; private set; }

        public static Restaurante Create(int idreservaciones, DateTime fecha, float monto)
        {
            return
                new Restaurante()
                {
                    IdReservaciones = idreservaciones,
                    Fecha = fecha,
                    Monto = monto
                };
        }
    }
}
