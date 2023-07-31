using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Servicios;
using Proyecto_Turismo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Application.Contracs.Services
{
    public interface IServicioService
    {
        EditServicesDTO Get(int id);
        IEnumerable<ListServicesDTO> GetAll();

        Result<int> Create(CreateServicesDTO dto);

        Result Edit(EditServicesDTO dto);

        Result Delete(int id);
    }
}
