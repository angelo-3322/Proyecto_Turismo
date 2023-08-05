using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Domain.DTOs.Producto;

namespace Proyecto_Turismo.Application.Contracs.Services
{
    public interface IProductoService
    {
        EditProductoDTO Get(int id);

        IEnumerable<ListProductoDTO> GetAll();

        Result<int> Create(CreateProductoDTO dto);

        Result Edit(EditProductoDTO dto);

        Result Delete(int id);
    }
}
