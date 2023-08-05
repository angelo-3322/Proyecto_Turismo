using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Domain.DTOs.Cliente;

namespace Proyecto_Turismo.Application.Contracs.Services
{
    public interface IClienteService
    {
        EditClienteDTO Get(int id);

        IEnumerable<ListClienteDTO> GetAll();

        Result<int> Create(CreateClienteDTO dto);

        Result Edit(EditClienteDTO dto);

        Result Delete(int id);
    }
}
