using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PIISTECHLTD.Application.ViewModel.Auth;
using PIISTECHLTD.SharedKernel.Entities.Auth;

namespace PIISTECHLTD.WebApp.Controllers;

public class AccountController(SignInManager<AppUser> inManager, UserManager<AppUser> userManager) : Controller
{
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVm loginVm)
    {
        if (ModelState.IsValid)
        {
            var result =
                await inManager.PasswordSignInAsync(loginVm.UserName!, loginVm.Password!, loginVm.RememberMe,
                    false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(loginVm);
        }
        return View(loginVm);
    }
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Registrar()
    {
        return View();
    }
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Registrar(RegistrarVm registrar)
    {
        if (ModelState.IsValid)
        {
            AppUser appUser = new()
            {
                UserName = registrar.Email,
                Name = registrar.Name,
                Email = registrar.Email,
                Address = registrar.Address
            };
            var result = await userManager.CreateAsync(appUser, registrar.Password!);
            if (result.Succeeded)
            {
                await inManager.SignInAsync(appUser, false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

        }


        return View();
    }
   
    public async Task<IActionResult> Logout()
    {
        await inManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
}
