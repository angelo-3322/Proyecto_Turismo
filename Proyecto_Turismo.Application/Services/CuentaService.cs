using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Cuenta;
using Proyecto_Turismo.Domain.Entities;


namespace Proyecto_Turismo.Application.Services
{
    public class CuentaService : ICuentaService
    {

        private readonly ICuentaRepository _repository;

        public CuentaService(ICuentaRepository repository)
        {
            _repository = repository;
        }

        public EditAccountDTO Get(int id)
        {
            Cuenta account = _repository.Get(s => s.Id == id);
            return new EditAccountDTO(account.Id, account.Usuario, account.Contrasena);
        }

        public IEnumerable<ListAccountDTO> GetAll()
        {
            List<Cuenta> cuentas =
                _repository.GetAll
                    (s => !string.IsNullOrEmpty(s.Usuario) || string.IsNullOrEmpty(s.Contrasena),
                    includes: i => i.Cliente).ToList();

            return cuentas.ConvertAll
                (s => new ListAccountDTO(s.Id,s.Cliente.Nombre, s.Usuario, s.Contrasena));
        }

        public Result<int> Create(CreateAccountDTO dto)
        {
            Cuenta cuenta =
                Cuenta.Create
                (
                    dto.IdCliente,
                    dto.Usuario,
                    dto.Contrasena
                );

            try
            {
                _repository.Instert(cuenta);
                _repository.Save();
            }
            catch
            {
                return Result.Fail<int>("Internal server error.");
            }

            return Result.Ok<int>(cuenta.Id);
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Result Edit(EditAccountDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
