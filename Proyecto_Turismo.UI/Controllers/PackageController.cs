﻿using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Domain.DTOs.Paquetes;
using Proyecto_Turismo.UI.Models.ViewModels;

namespace Proyecto_Turismo.UI.Controllers
{
    public class PackageController : Controller
    {
        private readonly IPaqueteService _paqueteService;

        public PackageController(IPaqueteService paqueteService)
        {
            _paqueteService = paqueteService;
        }

        public IActionResult Index()
        {
            var Package = _paqueteService.GetAll();
            return View(Package);
        }

        public IActionResult Packages()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreatePackageViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreatePackageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _paqueteService.Create(model.Packages);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }



            return View(model);
        }

        [HttpGet("/package/edit/{id}")]
        public IActionResult Edit([FromRoute] int id)
        {
            var package = _paqueteService.Get(id);
            var model =
                new EditPackageViewModel
                {
                    Nombre = package.Nombre,
                    Descripcion = package.Descripcion,
                    Precio = package.Precio,

                };

            return View(model);
        }

        [HttpPost("/package/edit/{id}")]
        public IActionResult Edit([FromRoute] int id, EditPackageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = new EditPackageDTO(id,model.Nombre,model.Precio,model.Descripcion);
                var result = _paqueteService.Edit(client);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }
            return View(model);
        }

        [HttpDelete("/package/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return Json(new { success = false, message = "ID inválido." });
            }

            var result = _paqueteService.Delete(id);

            if (!result.IsSuccess)
            {
                return Json(new { success = false, message = result.Error });
            }

            return Json(new { success = true });
        }

    }
}
