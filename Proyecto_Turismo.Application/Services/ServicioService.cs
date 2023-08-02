using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Servicios;
using Proyecto_Turismo.Domain.Entities;


namespace Proyecto_Turismo.Application.Services
{
    public class ServicioService : IServicioService
    {

        private readonly IServicioRepository _repository;

        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }

        public EditServicesDTO Get(int id)
        {
            Servicio services = _repository.Get(s => s.Id == id);
            return new EditServicesDTO(services.Id, services.Nombre, services.Precio);
        }

        public IEnumerable<ListServicesDTO> GetAll()
        {
            List<Servicio> servicios =
                _repository.GetAll
                    (s => !string.IsNullOrEmpty(s.Nombre) || string.IsNullOrEmpty(s.Precio.ToString())).ToList();



            return servicios.ConvertAll
                (s => new ListServicesDTO(s.Id, s.Nombre, s.Precio));
        }

        public Result<int> Create(CreateServicesDTO dto)
        {
            Servicio servicio =
                Servicio.Create
                (
                    dto.Nombre,
                    dto.Precio
                );

            try
            {
                _repository.Instert(servicio);
                _repository.Save();
            }
            catch
            {
                return Result.Fail<int>("Internal server error.");
            }

            return Result.Ok<int>(servicio.Id);
        }

        public Result Edit(EditServicesDTO dto)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
