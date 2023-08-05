using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Domain.DTOs.Imagen;

namespace Proyecto_Turismo.Application.Contracs.Services
{
    public interface IImagenService
    {
        EditImagenDTO Get(int id);

        IEnumerable<ListImagenDTO> GetAll();

        Result<int> Create(CreateImagenDTO dto);

        Result Edit(EditImagenDTO dto);

        Result Delete(int id);
    }
}
