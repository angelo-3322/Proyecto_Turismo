using Proyecto_Turismo.Domain.DTOs.Habitaciones;
using Proyecto_Turismo.Domain.DTOs.Paquetes;
using Proyecto_Turismo.Domain.DTOs.Reservaciones;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.UI.Models.ViewModels.AccountModels
{
    public class CreateReservationModel
    {
        public EditHotelRoomDTO Habitacion { get; set; }
        public List<ListPackageDTO> PaquetesDisponibles { get; set; }
        public int PaqueteSeleccionado { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public DateTime FechaFin { get; set; } = DateTime.Now.AddDays(1);
        public int Dias { get; set; }
        public float Total { get; set; }
        public CreateReservationDTO Reservations { get; set; }

        
    }
}
