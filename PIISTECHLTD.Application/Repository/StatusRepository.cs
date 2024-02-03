using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using PIISTECHLTD.Application.Repository.Base;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.Data.Persistence;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Application.Repository;

public class StatusRepository(IMapper mapper, ApplicationDbContext context) : BaseRepository<Status, StatusVm, long>(mapper, context), IStatusRepository
{
    public IEnumerable<SelectListItem> Dropdown()
    {
        return DbSet.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
    }
}
