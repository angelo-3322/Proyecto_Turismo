using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Cuenta;
using Proyecto_Turismo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Application.Contracs.Services
{
    public interface ICuentaService
    {
        EditAccountDTO Get(int id);

        IEnumerable<ListAccountDTO> GetAll();

        Result<int> Create(CreateAccountDTO dto);

        Result Edit(EditAccountDTO dto);

        Result Delete(int id);
    }
}
