
using Proyecto_Turismo.Application.Components;

namespace Proyecto_Turismo.Application.Contracs.Identity
{
    public interface IAccountService
    {
        Task<Result> Register(string email, string password, string role);
        Task<Result> Login(string email, string password);
    }
}
