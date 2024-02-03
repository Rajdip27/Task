using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PIISTECHLTD.Application.Repository;
using PIISTECHLTD.Application.Repositoryp;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.SharedKernel.Entities;
namespace PIISTECHLTD.WebApp.Controllers.Admin;

public class ReceiverController(IReceiverRepository receiverRepository, IMapper mapper) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index() => View(await receiverRepository.GetAllAsync());
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(long id)
    {
        if (id == 0)
            return View(new ReceiverVm());
        else
            return View(await receiverRepository.FirstOrDefaultAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(long id, ReceiverVm model)
    {
        if (id == 0)
        {
            //Data Save
            if (ModelState.IsValid)
            {
                await receiverRepository.InsertAsync(mapper.Map<Receiver>(model));
                return RedirectToAction(nameof(Index));
            }
        }
        else
        {
            //data Update
            if (ModelState.IsValid)
            {
                await receiverRepository.UpdateAsync(id, mapper.Map<Receiver>(model));
                return RedirectToAction(nameof(Index));
            }
        }
        return View(model);
    }
    public async Task<IActionResult> Delete(long id)
    {
        if (id != 0)
        {
            await receiverRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index));
    }
}
