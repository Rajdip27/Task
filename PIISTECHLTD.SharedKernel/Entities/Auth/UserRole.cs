using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIISTECHLTD.SharedKernel.Entities.Auth;
[Table("UserRoles")]
public class UserRole: IdentityUserRole<string>
{
}
