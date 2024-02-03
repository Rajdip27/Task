using Microsoft.AspNetCore.Mvc.Rendering;
using PIISTECHLTD.Application.Repository.Base;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Application.Repository;

public interface IStatusRepository:IBaseRepository<Status, StatusVm,long>
{
    public IEnumerable<SelectListItem> Dropdown();
}
