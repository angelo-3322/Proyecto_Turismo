using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Domain.DTOs.Menu;
using Proyecto_Turismo.Domain.DTOs.Producto;
using Proyecto_Turismo.UI.Models.ViewModels;
using Proyecto_Turismo.UI.Models.ViewModels.AccountModels;

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
            var model = new List<ProductoViewModel>();

            foreach (var product in products)
            {
                var menu = _menuService.Get(product.IdMenu);
                var productViewModel = new ProductoViewModel
                {
                    Producto = product,
                    NombreMenu = menu.Nombre
                };
                model.Add(productViewModel);
            }

            return View(model);
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
            var menusEn = _menuService.GetAll();
            var menus = menusEn.Select(m => new ListMenuDTO(m.Id, m.Nombre)).ToList();

            var model =
                new EditProductViewModel
                {
                    Product = new EditProductoDTO
                    {
                        Id = product.Id,
                        Nombre = product.Nombre,
                        Descripcion = product.Descripcion,
                        Precio = product.Precio,
                        IdMenu = product.IdMenu
                    },
                    Menus = menus
                };

            return View(model);
        }


        [HttpPost("/product/edit/{id}")]
        public IActionResult Edit([FromRoute] int id, EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new EditProductoDTO(id, model.Product.Nombre, model.Product.Descripcion, model.Product.Precio, model.Product.IdMenu);
                var result = _productoService.Edit(product);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, result.Error);
            }

            var menuEntities = _menuService.GetAll();
            var menus = menuEntities.Select(m => new ListMenuDTO
            {
                Id = m.Id,
                Nombre = m.Nombre
            }).ToList();
            model.Menus = menus;
            return View(model);
        }

        [HttpDelete("/product/delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _productoService.Delete(id);
            return Json(new { success = result.IsSuccess, error = result.Error });
        }
    }
}
