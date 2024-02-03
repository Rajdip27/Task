using AspNetCore.Reporting;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PIISTECHLTD.Application.Repository;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.SharedKernel.Entities;
using System.Net.Mime;
using System.Text;

namespace PIISTECHLTD.WebApp.Controllers.Admin;
[Authorize(Roles = "Administrator")]
public class ShipperController(IShipperRepository shipperRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment) : Controller
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
    [HttpGet]
    public async Task<ActionResult> Print()
    {
        var data = await shipperRepository.GetAllAsync();
        string reportName = "TestReport.pdf";
        string reportPath = Path.Combine(webHostEnvironment.ContentRootPath, "Reports", "ShipperReport.rdlc");
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding.GetEncoding("utf-8");
        LocalReport report = new LocalReport(reportPath);
        report.AddDataSource("ShipperDbSet", data.ToList());

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
