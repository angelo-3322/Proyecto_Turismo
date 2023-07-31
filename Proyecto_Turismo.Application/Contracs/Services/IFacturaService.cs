using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Facturas;
using Proyecto_Turismo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Application.Contracs.Services
{
    public interface IFacturaService
    {
        EditFactureDTO Get(int id);

        IEnumerable<ListFactureDTO> GetAll();

        Result<int> Create(CreateFactureDTO dto);

        Result Edit(EditFactureDTO dto);

        Result Delete(int id);
    }
}
