using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Proyecto_Turismo.Domain.Entities
{
    public class Reservacion
    {
        public Reservacion() { }

        [Key]
        public int Id { get; private set; }

        [Required]
        [ForeignKey("Habitacion")]
        public int IdHabitaciones { get; private set; }

        public Habitacion Habitacion { get; private set; }


        [Required]
        [ForeignKey("Paquete")]
        public int IdPaquete { get; private set; }

        public Paquete Paquete { get; private set; }


        [Required]
        [ForeignKey("Cliente")]
        public int IdCliente { get; private set; }

        public Cliente Cliente { get; private set; }

        [Required]
        public DateTime FechaInicio { get; private set; }

        [Required]
        public DateTime FechaFin { get; private set; }

        [Required]
        public bool Activa { get; private set; }

        public static Reservacion Create(int idhabitaciones, int idpaquete, int idcliente, DateTime fechainicio, DateTime fechafin)
        {
            return
                new Reservacion()
                {
                    IdHabitaciones = idhabitaciones,
                    IdPaquete = idpaquete,
                    IdCliente = idcliente,
                    FechaInicio = fechainicio,
                    FechaFin = fechafin,
                    Activa = true
                };
        }
    }
}
