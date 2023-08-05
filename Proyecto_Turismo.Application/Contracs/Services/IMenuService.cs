using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Domain.DTOs.Menu;

namespace Proyecto_Turismo.Application.Contracs.Services
{
    public interface IMenuService
    {
        EditMenuDTO Get(int id);

        IEnumerable<ListMenuDTO> GetAll();

        Result<int> Create(CreateMenuDTO dto);

        Result Edit(EditMenuDTO dto);

        Result Delete(int id);
    }
}
