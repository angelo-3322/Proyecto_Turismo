using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Services;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Facturas;
using Proyecto_Turismo.UI.Models.ViewModels;

namespace Proyecto_Turismo.UI.Controllers
{
    public class FactureController : Controller
    {
        private readonly IFacturaService _facturaService;
        private readonly IReservacionService _reservacionService;

        public FactureController(IFacturaService facturaService, IReservacionService reservacionService)
        {
            _facturaService = facturaService;
            _reservacionService = reservacionService;
        }
        public IActionResult Index()
        {
            var facturas = _facturaService.GetAll();
            return View(facturas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateFactureViewModel();
            model.Reservations = _reservacionService.GetAll().ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateFactureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _facturaService.Create(model.Facture);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }

            model.Reservations = _reservacionService.GetAll().ToList();
            return View(model);
        }
        [HttpGet("/facture/edit/{id}")]
        public IActionResult Edit([FromRoute] int id)
        {
            var facture = _facturaService.Get(id);
            var model =
                new EditFactureViewModel
                {
                    FechaEmision = facture.FechaEmision,
                    Monto = facture.Monto,

                };

            return View(model);
        }

        [HttpPost("/facture/edit/{id}")]
        public IActionResult Edit([FromRoute] int id, EditFactureViewModel model)
        {
            if (ModelState.IsValid)
            {
                var facture = new EditFactureDTO(id, model.FechaEmision, model.Monto);
                var result = _facturaService.Edit(facture);

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
