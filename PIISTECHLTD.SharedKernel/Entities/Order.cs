using PIISTECHLTD.SharedKernel.Common;
using System.ComponentModel.DataAnnotations;

namespace PIISTECHLTD.SharedKernel.Entities;

public class Order: AuditableEntity
{
    public Order() => Shipments = new List<Shipment>();
    public List<Shipment> Shipments { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    
    
}
