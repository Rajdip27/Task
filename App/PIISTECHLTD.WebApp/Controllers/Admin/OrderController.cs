using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PIISTECHLTD.Application.Repository;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.SharedKernel.Entities;
using System.Security.Claims;

namespace PIISTECHLTD.WebApp.Controllers.Admin;

[Authorize(Roles = "Employee,Administrator")]
public class OrderController(IOrderRepository orderRepository,IMapper mapper) : Controller
{
    public async Task<IActionResult> Index()
    {
        var data = await orderRepository.GetAllAsync(x => x.User);
        return View(data);
    }

    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(long id)
    {
        if (id == 0) return View(new OrderVm());
        else
        {
            return View(await orderRepository.FirstOrDefaultAsync(id));
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(long id, OrderVm model)
    {
        if (User.Identity.IsAuthenticated)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           if(userId is not null)
           {
                model.UserId = userId;
                if (id == 0)
                {
                    if (ModelState.IsValid)
                    {
                        await orderRepository.InsertAsync(mapper.Map<Order>(model));
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    await orderRepository.UpdateAsync(id, mapper.Map<Order>(model));
                    return RedirectToAction(nameof(Index));
                }
           }
           
        }
        return RedirectToAction("Registrar", "Account");
    }
}
