using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Paquetes;
using Proyecto_Turismo.Domain.Entities;


namespace Proyecto_Turismo.Application.Services
{
    public class PaqueteService : IPaqueteService
    {

        private readonly IPaqueteRepository _repository;

        public PaqueteService(IPaqueteRepository repository)
        {
            _repository = repository;
        }

        public EditPackageDTO Get(int id)
        {
            Paquete package = _repository.Get(s => s.Id == id);
            return new EditPackageDTO(package.Id, package.Nombre, package.Precio);
        }

        public IEnumerable<ListPackageDTO> GetAll()
        {
            List<Paquete> paquetes =
                _repository.GetAll
                    (s => !string.IsNullOrEmpty(s.Nombre) || string.IsNullOrEmpty(s.Precio.ToString())).ToList();

            return paquetes.ConvertAll
                (s => new ListPackageDTO(s.Id, s.Nombre, s.Precio));
        }

        public Result<int> Create(CreatePackageDTO dto)
        {
            Paquete paquete =
                Paquete.Create
                (
                    dto.Nombre,
                    dto.precio
                );

            try
            {
                _repository.Instert(paquete);
                _repository.Save();
            }
            catch
            {
                return Result.Fail<int>("Internal server error.");
            }

            return Result.Ok<int>(paquete.Id);
        }

        public Result Edit(EditPackageDTO dto)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
