using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Application.Contracs.Services
{
    public interface IClienteService
    {
        EditClientDTO Get(int id);

        IEnumerable<ListClientDTO> GetAll();

        Result<int> Create(CreateClientDTO dto);

        Result Edit(EditClientDTO dto);

        Result Delete(int id);
    }
}
