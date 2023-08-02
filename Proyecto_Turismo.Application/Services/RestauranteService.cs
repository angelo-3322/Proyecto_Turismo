using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Facturas;
using Proyecto_Turismo.Domain.DTOs.Restaurante;
using Proyecto_Turismo.Domain.Entities;


namespace Proyecto_Turismo.Application.Services
{
    public class RestauranteService : IRestauranteService
    {

        private readonly IRestauranteRepository _repository;

        public RestauranteService(IRestauranteRepository repository)
        {
            _repository = repository;
        }

        public EditRestaurantDTO Get(int id)
        {
            Restaurante restaurant = _repository.Get(s => s.Id == id);
            return new EditRestaurantDTO(restaurant.Id, restaurant.Nombre,restaurant.IdMenu);
        }

        public IEnumerable<ListRestaurantDTO> GetAll()
        {
            List<Restaurante> restaurantes =
                _repository.GetAll
                    (s => string.IsNullOrEmpty(s.Nombre.ToString()),
                    includes: i => i.menu).ToList();

            return restaurantes.ConvertAll
                (s => new ListRestaurantDTO(s.Id,s.Nombre,s.IdMenu));
        }

        public Result<int> Create(CreateRestaurantDTO dto)
        {
            Restaurante restaurante =
                Restaurante.Create
                (
                    dto.Nombre,
                    dto.IdMenu
                );

            try
            {
                _repository.Instert(restaurante);
                _repository.Save();
            }
            catch
            {
                return Result.Fail<int>("Internal server error.");
            }

            return Result.Ok<int>(restaurante.Id);
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Result Edit(EditRestaurantDTO dto)
        {
            throw new NotImplementedException();
        }




    }
}
