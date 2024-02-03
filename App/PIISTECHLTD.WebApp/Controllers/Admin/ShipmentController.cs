using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PIISTECHLTD.Application.Repository;
using PIISTECHLTD.Application.Repositoryp;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.WebApp.Controllers.Admin;
[Authorize(Roles = "Administrator")]
public class ShipmentController(IShipmentRepository shipmentRepository, IStatusRepository statusRepository, IReceiverRepository receiverRepository,IShipperRepository shipperRepository  ,IMapper mapper,IUserRepository userRepository) : Controller
{
    

    [HttpGet]
    public async Task<IActionResult> Index() => View(await shipmentRepository.GetAllAsync(x=>x.Shipper, x => x.Receiver, x => x.Status));
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(long id)
    {
        #region Dropdown
        ViewData["StatusId"] = statusRepository.Dropdown();
        ViewData["ShipperId"] = shipperRepository.Dropdown();
        ViewData["ReceiverId"] = receiverRepository.Dropdown();
        ViewData["UserId"] = userRepository.Dropdown();

        #endregion
        if (id == 0)
            return View(new ShipmentVm());
        else
            return View(await shipmentRepository.FirstOrDefaultAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(long id, ShipmentVm model)
    {
        if (id == 0)
        {
            //Data Save
            if (ModelState.IsValid)
            {
                await shipmentRepository.InsertAsync(mapper.Map<Shipment>(model));
                return RedirectToAction(nameof(Index));
            }
        }
        else
        {
            //data Update
            if (ModelState.IsValid)
            {
                await shipmentRepository.UpdateAsync(id, mapper.Map<Shipment>(model));
                return RedirectToAction(nameof(Index));
            }
        }
        return View(model);
    }
    public async Task<IActionResult> Delete(long id)
    {
        if (id != 0)
        {
            await shipmentRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index));
    }
}
