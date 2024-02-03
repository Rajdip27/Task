using AspNetCore.Reporting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIISTECHLTD.Application.ViewModel.Auth;
using PIISTECHLTD.SharedKernel.Entities.Auth;
using System.Net.Mime;
using System.Text;

namespace PIISTECHLTD.WebApp.Controllers;

public class AccountController(SignInManager<AppUser> inManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment) : Controller
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
                // Check if the role exists, and create it if not
                var roleExists = await roleManager.RoleExistsAsync("User");
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                }

                // Assign the "User" role to the registered user
                await userManager.AddToRoleAsync(appUser, "User");

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

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> Print( )
    {
        var data =  await userManager.Users.ToListAsync();
        string reportName = "TestReport.pdf";
        string reportPath = Path.Combine(webHostEnvironment.ContentRootPath, "Reports", "CustomerList.rdlc");
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding.GetEncoding("utf-8");
        LocalReport report = new LocalReport(reportPath);
        report.AddDataSource("CustomerDbSet", data.ToList());

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        var result = report.Execute(RenderType.Pdf, 2, parameters);
        var content = result.MainStream.ToArray();
        var contentDisposition = new ContentDisposition
        {
            FileName = reportName,
            Inline = true,
        };
        Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
        return File(content, MediaTypeNames.Application.Pdf);
    }
}
