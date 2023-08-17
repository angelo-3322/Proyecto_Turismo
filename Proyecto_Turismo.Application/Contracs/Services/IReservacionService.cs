using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Facturas;
using Proyecto_Turismo.Domain.DTOs.Reservaciones;
using Proyecto_Turismo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Application.Contracs.Services
{
    public interface IReservacionService
    {
        EditReservationDTO Get(int id);
        IEnumerable<ListReservationDTO> GetAll();

        Result<int> Create(CreateReservationDTO dto);

        Result Edit(EditReservationDTO dto);

        Result Delete(int id);
    }
}
