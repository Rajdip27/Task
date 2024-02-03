using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PIISTECHLTD.Application.Repository;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.SharedKernel.Entities;
namespace PIISTECHLTD.WebApp.Controllers.Admin;

public class StatusController(IStatusRepository statusRepository,IMapper mapper) : Controller
{
   

    [HttpGet]
    public async Task<IActionResult> Index() => View(await statusRepository.GetAllAsync());
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(long id)
    {
        if (id == 0)
            return View(new StatusVm());
        else
            return View(await statusRepository.FirstOrDefaultAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(long id, StatusVm model)
    {
        if (id == 0)
        {
            //Data Save
            if (ModelState.IsValid)
            {
                await statusRepository.InsertAsync(mapper.Map<Status>(model));
                return RedirectToAction(nameof(Index));
            }
        }
        else
        {
            //data Update
            if (ModelState.IsValid)
            {
                await statusRepository.UpdateAsync(id, mapper.Map<Status>(model));
                return RedirectToAction(nameof(Index));
            }
        }
        return View(model);
    }
    public async Task<IActionResult> Delete(long id)
    {
        if (id != 0)
        {
            await statusRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index));
    }
}
