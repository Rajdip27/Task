using AspNetCore.Reporting;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PIISTECHLTD.Application.Repository;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.Application.ViewModel.ShowDataViewModel;
using PIISTECHLTD.SharedKernel.Entities;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;

namespace PIISTECHLTD.WebApp.Controllers.Admin;

[Authorize(Roles = "User,Administrator")]
public class OrderController(IOrderRepository orderRepository,IMapper mapper, IWebHostEnvironment webHostEnvironment) : Controller
{
    public async Task<IActionResult> Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is not null)
            {
                var data = await orderRepository.GetData(userId);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
        }


        return RedirectToAction("Index", "Home");
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
                        return RedirectToAction("Index", "Home");
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
    [HttpGet]
    public async Task<ActionResult> Print()
    {
        if (User.Identity.IsAuthenticated)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is not null)
            {
                var data = await orderRepository.GetData(userId);

                // Check if data is a single object, and convert it to a list
                var dataList = new List<object> { data };

                string reportName = "TestReport.pdf";
                string reportPath = Path.Combine(webHostEnvironment.ContentRootPath, "Reports", "ConsignmentReport.rdlc");

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding.GetEncoding("utf-8");
                LocalReport report = new LocalReport(reportPath);

                // Use dataList instead of data
                report.AddDataSource("ConsignmentDbSet", dataList);

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
        return NotFound();
    }


}
