using PIISTECHLTD.SharedKernel.Common;
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
    [Required]
    public ShipmentStatus Status { get; set; }
    [Required]
    public string ConsignmentNumber { get; set; }
}
