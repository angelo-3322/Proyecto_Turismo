using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.Entities;


namespace Proyecto_Turismo.Application.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public EditClientDTO Get(int id)
        {
            Cliente client = _repository.Get(s => s.Id == id);
            return new EditClientDTO(client.Id, client.Nombre, client.Email, client.Telefono);
        }

        public IEnumerable<ListClientDTO> GetAll()
        {
            List<Cliente> clients =
                _repository.GetAll
                    (s => !string.IsNullOrEmpty(s.Nombre) || string.IsNullOrEmpty(s.Email) || string.IsNullOrEmpty(s.Telefono.ToString())).ToList();

            return clients.ConvertAll
                (s => new ListClientDTO(s.Id, s.Nombre, s.Email, s.Telefono));
        }

        public Result<int> Create(CreateClientDTO dto)
        {
            Cliente task = 
                Cliente.Create
                (
                    dto.Nombre, 
                    dto.Email, 
                    dto.Telefono
                );

            try
            {
                _repository.Instert(task);
                _repository.Save();
            }
            catch
            {
                return Result.Fail<int>("Internal server error.");
            }

            return Result.Ok<int>(task.Id);
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Result Edit(EditClientDTO dto)
        {
            throw new NotImplementedException();
        }


    }
}
