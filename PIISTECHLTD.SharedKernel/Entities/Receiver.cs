using PIISTECHLTD.SharedKernel.Common;
using System.ComponentModel.DataAnnotations;

namespace PIISTECHLTD.SharedKernel.Entities;

public class Receiver: AuditableEntity

{
    [Required]
    public string ReceiverName { get; set; }
    [Required]
    public string ReceiverAddress { get; set; }
    [Required]
    public string ReceiverPhoneNumber { get; set; }
    public ICollection<Shipment> Shipment { get; set; } = new HashSet<Shipment>();

}
