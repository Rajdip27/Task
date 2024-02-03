using PIISTECHLTD.SharedKernel.Common;
using PIISTECHLTD.SharedKernel.Entities.Auth;
using System.ComponentModel.DataAnnotations;

namespace PIISTECHLTD.SharedKernel.Entities;

public class Order: AuditableEntity
{
    
    [Required]
    public DateTime OrderDate { get; set; }
    public string ProductName { get; set; }
    public string Address { get; set; }
    public String UserId { get; set; }
    public AppUser User { get; set; }
}
