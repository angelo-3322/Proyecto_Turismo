using Microsoft.EntityFrameworkCore;
using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Application.Contracs.Repositories;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Domain.DTOs.Producto;
using Proyecto_Turismo.Domain.Entities;
using System.Linq.Expressions;

namespace Proyecto_Turismo.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }
        public Result<int> Create(CreateProductoDTO dto)
        {
            Producto prod = Producto.Create
            (
               dto.Nombre,
               dto.Descripcion,
               dto.Precio,
               dto.IdMenu
            );

            try
            {
                _repository.Instert(prod);
                _repository.Save();

                return Result.Ok<int>(prod.Id);
            }
            catch
            {
                return Result.Fail<int>("Internal server error.");
            }
        }

        public Result Delete(int id)
        {
            var prod = _repository.Get(m => m.Id == id);
            if (prod == null)
            {
                return Result.Fail("Producto no encontrado");
            }

            _repository.Delete(prod);
            _repository.Save();

            return Result.Ok();
        }

        public Result Edit(EditProductoDTO dto)
        {
            var prod = _repository.Get(m => m.Id == dto.Id);
            if (prod == null)
            {
                return Result.Fail("Producto not found");
            }

            prod.Nombre = dto.Nombre;
            prod.Descripcion = dto.Descripcion;
            prod.Precio = dto.Precio;
            prod.IdMenu = dto.IdMenu;

            try
            {
                _repository.Update(prod);
                _repository.Save();

                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Internal server error.");
            }
        }

        public EditProductoDTO Get(int id)
        {
            Producto prod = _repository.Get(s => s.Id == id);
            return new EditProductoDTO(prod.Id, prod.Nombre,prod.Descripcion,prod.Precio,prod.IdMenu);
        }

        public IEnumerable<ListProductoDTO> GetAll()
        {
            var prod = _repository.GetAll().ToList();

            return prod.ConvertAll(p => new ListProductoDTO
            (
                p.Id,
                p.Nombre,
                p.Descripcion,
                p.Precio,
                p.IdMenu
            ));
        }

        public List<ListProductoDTO> GetByMenu(int menuId)
        {
            var prod = _repository.GetAll().Where(p => p.IdMenu == menuId).ToList();
            return prod.ConvertAll(p => new ListProductoDTO
            (
                p.Id,
                p.Nombre,
                p.Descripcion,
                p.Precio,
                p.IdMenu
            ));
        }

    }
}
