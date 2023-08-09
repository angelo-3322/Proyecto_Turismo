﻿using Microsoft.AspNetCore.Mvc;
using Proyecto_Turismo.Application.Contracs.Identity;
using Proyecto_Turismo.UI.Models.ViewModels.AccountModels;

namespace ToDo.IU.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterInputModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Register(inputModel.Email, inputModel.Password, inputModel.Role);
                if (result.IsSuccess)
                {
                    result = await _accountService.Login(inputModel.Email, inputModel.Password);

                    if (result.IsSuccess)
                    {
                       return LocalRedirect("/home/index");
                    }
                    
                }
                ModelState.AddModelError(string.Empty, result.Error);
            }

            return View(inputModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginInputModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Login(inputModel.Email, inputModel.Password);

                    if (result.IsSuccess)
                    {
                        return LocalRedirect("/home/index");
                    }

                
                ModelState.AddModelError(string.Empty, result.Error);
            }

            return View(inputModel);
        }
    }
}