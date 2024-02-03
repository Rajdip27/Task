using AutoMapper;
using PIISTECHLTD.SharedKernel.Common;
using PIISTECHLTD.SharedKernel.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PIISTECHLTD.Application.ViewModel;
[AutoMap(typeof(Receiver),ReverseMap = true)]
public class ReceiverVm:BaseEntity
{
    [Required]
    [DisplayName("Receiver Name")]
    public string ReceiverName { get; set; }
    [Required]
    [DisplayName("Address")]
    public string ReceiverAddress { get; set; }
    [Required]
    [DisplayName("Phone Number")]
    public string ReceiverPhoneNumber { get; set; }
    public ICollection<ShipmentVm> Shipment { get; set; } = new HashSet<ShipmentVm>();
}
