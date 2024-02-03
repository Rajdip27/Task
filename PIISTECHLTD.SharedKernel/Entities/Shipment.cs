using PIISTECHLTD.SharedKernel.Common;
using PIISTECHLTD.SharedKernel.Entities.Auth;
using System.ComponentModel.DataAnnotations;

namespace PIISTECHLTD.SharedKernel.Entities;

public class Shipment: AuditableEntity
{
    [Required]
    public long ShipperId { get; set; }
    public Shipper Shipper { get; set; }
    [Required]
    public long ReceiverId { get; set; }
    public Receiver Receiver { get; set; }
    [Required]
    public DateTime ShipmentDate { get; set; }
    [Required]
    public decimal ShipmentCost { get; set; }
   
    public long StatusId { get; set; }
    public Status Status { get; set; }
    [Required]
    public string ConsignmentNumber { get; set; }
    public ICollection<Order> Orders { get; set; }

    public string UserId { get; set; }
    public AppUser AppUser { get; set; }
}
