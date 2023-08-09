using Microsoft.AspNetCore.Identity;
using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Application.Contracs.Identity;
using System.Text;

namespace Proyecto_Turismo.Infrastructure.Identity
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<Result> Login(string email, string password)
        {
            var result =
               await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (!result.Succeeded)
            {
                return Result.Fail("Usuario o contraseña invalida");
            }

            return Result.Ok();
        }

        public async Task<Result> Register(string email, string password, string role)
        {
            var user = new IdentityUser { UserName = email, Email = email,};
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    builder.AppendLine(error.Description);
                }
                return Result.Fail(builder.ToString());
            }
            if (role == "Comun" || role == "Admin") // roles permitidos
            {
                var roleResult = await _userManager.AddToRoleAsync(user, role);
                if (!roleResult.Succeeded)
                {
                    // Manejar el error si la asignación del rol falla
                    return Result.Fail("Error al asignar el rol.");
                }
            }
            else
            {
                return Result.Fail("Rol no válido.");
            }
            return Result.Ok();
        }
    }
}
