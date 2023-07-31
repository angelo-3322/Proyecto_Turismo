using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Facturas;
using Proyecto_Turismo.Domain.DTOs.Paquetes;
using Proyecto_Turismo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Turismo.Application.Contracs.Services
{
    public interface IPaqueteService
    {

        EditPackageDTO Get(int id);

        IEnumerable<ListPackageDTO> GetAll();

        Result<int> Create(CreatePackageDTO dto);

        Result Edit(EditPackageDTO dto);

        Result Delete(int id);
    }
}
