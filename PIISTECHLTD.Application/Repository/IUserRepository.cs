using Microsoft.AspNetCore.Mvc.Rendering;

namespace PIISTECHLTD.Application.Repository;

public interface IUserRepository
{
    public IEnumerable<SelectListItem> Dropdown();
}
