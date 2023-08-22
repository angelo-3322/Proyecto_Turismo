namespace Proyecto_Turismo.UI.Models.ViewModels.AccountModels
{
    public class MyReservationsViewModel
    {
        public List<ReservationDetails> Reservations { get; set; }

        public class ReservationDetails
        {
            public int ReservacionId { get; set; }
            public byte[] HabitacionImagen { get; set; }
            public int NumeroHabitacion { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public string UsuarioEmail { get; set; }
        }
    }
}
