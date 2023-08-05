using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Services;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.UI.Models.ViewModels;

namespace Proyecto_Turismo.UI.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClientController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            var clients = _clienteService.GetAll();
            return View(clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateClientViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _clienteService.Create(model.Clients);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }

            return View(model);
        }

        [HttpGet("/client/edit/{id}")]
        public IActionResult Edit([FromRoute] int id)
        {
            var client = _clienteService.Get(id);
            var model =
                new EditClientViewModel
                {
                    Nombre = client.Nombre,
                    Email = client.Email,
                    Telefono = client.Telefono,

                };

            return View(model);
        }

        [HttpPost("/client/edit/{id}")]
        public IActionResult Edit([FromRoute] int id, EditClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = new EditClienteDTO(id, model.Nombre, model.Email, model.Telefono);
                var result = _clienteService.Edit(client);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }
            return View(model);
        }
    }

}
