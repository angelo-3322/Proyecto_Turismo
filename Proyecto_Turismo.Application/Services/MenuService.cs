using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Application.Contracs.Repositories;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Domain.DTOs.Menu;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _repository;

        public MenuService(IMenuRepository repository)
        {
            _repository = repository;
        }
        public Result<int> Create(CreateMenuDTO dto)
        {
            Menu menu = Menu.Create
            (
               dto.Nombre
            );

            try
            {
                _repository.Instert(menu);
                _repository.Save();

                return Result.Ok<int>(menu.Id);
            }
            catch
            {
                return Result.Fail<int>("Internal server error.");
            }
        }

        public Result Delete(int id)
        {
            var menu = _repository.Get(m => m.Id == id);
            if (menu == null)
            {
                return Result.Fail("Menu not found");
            }

            try
            {
                _repository.Delete(menu);
                _repository.Save();

                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Internal server error.");
            }
        }

        public Result Edit(EditMenuDTO dto)
        {
            var menu = _repository.Get(m => m.Id == dto.Id);
            if (menu == null)
            {
                return Result.Fail("Menu not found");
            }

            menu.Nombre = dto.Nombre;

            try
            {
                _repository.Update(menu);
                _repository.Save();

                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Internal server error.");
            }
        }

        public EditMenuDTO Get(int id)
        {
            Menu menu = _repository.Get(s => s.Id == id);
            return new EditMenuDTO(menu.Id, menu.Nombre);
        }

        public IEnumerable<ListMenuDTO> GetAll()
        {
            var menus = _repository.GetAll().ToList();

            return menus.ConvertAll(m => new ListMenuDTO
            (
                m.Id,
                m.Nombre
            ));
        }
    }
}
