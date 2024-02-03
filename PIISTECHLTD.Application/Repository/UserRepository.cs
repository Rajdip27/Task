using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIISTECHLTD.SharedKernel.Entities.Auth;

namespace PIISTECHLTD.Application.Repository;

public class UserRepository : IUserRepository
{
    private readonly UserManager<AppUser> _userManager;

    public UserRepository(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    public IEnumerable<SelectListItem> Dropdown()
    {
        var users =  _userManager.Users.Select(x=> new SelectListItem { Text=x.Name,Value=x.Id}).ToList();
        return users;
    }
}
