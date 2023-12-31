﻿using Proyecto_Turismo.Domain.DTOs.Habitaciones;

namespace Proyecto_Turismo.UI.Models.ViewModels
{
    public class CreateHotelRoomViewModel
    {

        public CreateHotelRoomViewModel()
        {
            Rooms = new CreateHotelRoomDTO();
        }
        public CreateHotelRoomDTO Rooms { get; set; }
        public IFormFile ImageFile { get; set; } // tipo formulario para la imagen
    }

}
