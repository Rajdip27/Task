using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIISTECHLTD.Application.Repository.Base;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Application.Repositoryp;

public interface IReceiverRepository : IBaseRepository<Receiver, ReceiverVm, long>
{
    public IEnumerable<SelectListItem> Dropdown();
    
}
