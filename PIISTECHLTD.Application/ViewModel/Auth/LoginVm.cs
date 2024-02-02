using System.ComponentModel.DataAnnotations;

namespace PIISTECHLTD.Application.ViewModel.Auth;

public class LoginVm
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}
