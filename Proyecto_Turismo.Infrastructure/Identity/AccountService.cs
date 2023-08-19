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
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
            if (!(role == "Comun" || role == "Admin"))
            {
                return Result.Fail("Rol no válido.");
            }
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
            // Verificar si el rol ya existe
            if (!await _roleManager.RoleExistsAsync(role))
            {
                // Si no existe, crearlo
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(role));
                if (!roleResult.Succeeded)
                {
                    return Result.Fail("Error al crear el rol.");
                }
            }
            // Asignar el rol al usuario
            var addToRoleResult = await _userManager.AddToRoleAsync(user, role);
            if (!addToRoleResult.Succeeded)
            {
                return Result.Fail("Error al asignar el rol.");
            }
            return Result.Ok();
        }
        public async Task<Result> Logout()
        {
            await _signInManager.SignOutAsync();
            return Result.Ok();
        }
    }
}
