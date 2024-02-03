using AutoMapper;
using PIISTECHLTD.SharedKernel.Common;
using PIISTECHLTD.SharedKernel.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PIISTECHLTD.Application.ViewModel;
[AutoMap(typeof(Shipper), ReverseMap = true)]
public class ShipperVm:BaseEntity
{
    [Required]
    [DisplayName("Name: ")]
    public string ShipperName { get; set; }
    [Required]
    [DisplayName("Address: ")]
    public string ShipperAddress { get; set; }
    [Required]
    [DisplayName("Phone Number: ")]
    public string ShipperPhoneNumber { get; set; }
    public ICollection<ShipmentVm> Shipment { get; set; } = new HashSet<ShipmentVm>();
}
