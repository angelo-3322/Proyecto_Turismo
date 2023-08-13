using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Domain.DTOs.Producto;
using Proyecto_Turismo.UI.Models.ViewModels;

namespace Proyecto_Turismo.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductoService _productoService;
        private readonly IMenuService _menuService;

        public ProductController(IProductoService productoService, IMenuService menuService)
        {
            _productoService = productoService;
            _menuService = menuService;
        }

        public IActionResult Index()
        {
            var products = _productoService.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateProductViewModel();
            model.Menus = _menuService.GetAll().ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _productoService.Create(model.Products);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }

            model.Menus = _menuService.GetAll().ToList();
            return View(model);
        }

        [HttpGet("/product/edit/{id}")]
        public IActionResult Edit([FromRoute] int id)
        {
            var product = _productoService.Get(id);
            var model =
                new EditProductViewModel
                {
                    Nombre = product.Nombre,
                    Descripcion = product.Descripcion,
                    Precio = product.Precio,

                };

            return View(model);
        }

        [HttpPost("/product/edit/{id}")]
        public IActionResult Edit([FromRoute] int id, EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new EditProductoDTO(id, model.Nombre, model.Descripcion, model.Precio);
                var result = _productoService.Edit(product);

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
