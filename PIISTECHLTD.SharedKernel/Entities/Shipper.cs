using PIISTECHLTD.SharedKernel.Common;
using System.ComponentModel.DataAnnotations;

namespace PIISTECHLTD.SharedKernel.Entities;

public class Shipper: AuditableEntity

{
    [Required]
    public string ShipperName { get; set; }
    [Required]
    public string ShipperAddress { get; set; }
    [Required]
    public string ShipperPhoneNumber { get; set; }
    public ICollection<Shipment> Shipment { get; set; }=new HashSet<Shipment>();
}
