using Proyecto_Turismo.Domain.DTOs.Habitaciones;
using Proyecto_Turismo.Domain.DTOs.Reservaciones;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Turismo.UI.Models.ViewModels.AccountModels
{
    public class ReservacionViewModel
    {
        public ListReservationDTO Reservacion { get; set; }
        public string UsuarioEmail { get; set; }
    }
}
