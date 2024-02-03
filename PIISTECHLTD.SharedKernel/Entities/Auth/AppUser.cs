using Microsoft.AspNetCore.Identity;

namespace PIISTECHLTD.SharedKernel.Entities.Auth;

public class AppUser : IdentityUser
{
    public string Name { get; set; }
    public string Address { get; set; }

    public long CreatedBy { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }
    public ICollection<Order> Orders { get; set; }=new HashSet<Order>(); 
    public ICollection<Shipment> Shipment { get; set; }=new HashSet<Shipment>();
}
