using AutoMapper;
using PIISTECHLTD.SharedKernel.Common;
using PIISTECHLTD.SharedKernel.Entities;
using System.ComponentModel.DataAnnotations;

namespace PIISTECHLTD.Application.ViewModel;
[AutoMap(typeof(Shipper), ReverseMap = true)]
public class ShipperVm:BaseEntity
{
    [Required]
    public string ShipperName { get; set; }
    [Required]
    public string ShipperAddress { get; set; }
    [Required]
    public string ShipperPhoneNumber { get; set; }
    public ICollection<ShipmentVm> Shipment { get; set; } = new HashSet<ShipmentVm>();
}
