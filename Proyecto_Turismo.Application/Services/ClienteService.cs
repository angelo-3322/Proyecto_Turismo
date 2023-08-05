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

        public EditClienteDTO Get(int id)
        {
            Cliente client = _repository.Get(s => s.Id == id);
            return new EditClienteDTO(client.Id, client.Nombre, client.Email, client.Telefono);
        }

        public IEnumerable<ListClienteDTO> GetAll()
        {
            List<Cliente> clients =
                _repository.GetAll
                    (s => !string.IsNullOrEmpty(s.Nombre) || string.IsNullOrEmpty(s.Email) || string.IsNullOrEmpty(s.Telefono.ToString())).ToList();

            return clients.ConvertAll
                (s => new ListClienteDTO(s.Id, s.Nombre, s.Email, s.Telefono));
        }

        public Result<int> Create(CreateClienteDTO dto)
        {
            Cliente client = 
                Cliente.Create
                (
                    dto.Nombre, 
                    dto.Email, 
                    dto.Telefono
                );

            try
            {
                _repository.Instert(client);
                _repository.Save();
            }
            catch
            {
                return Result.Fail<int>("Internal server error.");
            }

            return Result.Ok<int>(client.Id);
        }
        public Result Edit(EditClienteDTO dto)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
