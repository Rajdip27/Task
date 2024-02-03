using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PIISTECHLTD.Application.Repository;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.WebApp.Controllers.Admin;
[Authorize(Roles = "Administrator")]
public class ShipperController(IShipperRepository shipperRepository, IMapper mapper) : Controller
{

    [HttpGet]
    public async Task<IActionResult> Index()=>View(await shipperRepository.GetAllAsync());
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(long id)
    {
        if (id == 0) 
            return View(new ShipperVm());
        else  
            return View(await shipperRepository.FirstOrDefaultAsync(id)); 
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(long id, ShipperVm model)
    {
        if (id == 0)
        {
            //Data Save
            if(ModelState.IsValid)
            {
                await shipperRepository.InsertAsync(mapper.Map<Shipper>(model));
                return RedirectToAction(nameof(Index));
            }
        }
        else
        {
            //data Update
            if (ModelState.IsValid)
            {
                await shipperRepository.UpdateAsync(id, mapper.Map<Shipper>(model));    
                return RedirectToAction(nameof(Index));
            }
        }
        return View(model);
    }
    public async Task<IActionResult>Delete(long id)
    {
        if (id != 0)
        {
            await shipperRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index));
    }


}
