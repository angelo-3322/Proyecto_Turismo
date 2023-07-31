using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Facturas;
using Proyecto_Turismo.Domain.DTOs.Habitaciones;
using Proyecto_Turismo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Application.Contracs.Services
{
    public interface IHabitacionService
    {
        EditHotelRoomDTO Get(int id);

        IEnumerable<ListHotelRoomDTO> GetAll();

        Result<int> Create(CreateHotelRoomDTO dto);

        Result Edit(EditHotelRoomDTO dto);

        Result Delete(int id);
    }
}
