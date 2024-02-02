using AutoMapper;
using PIISTECHLTD.SharedKernel.Common;
using PIISTECHLTD.SharedKernel.Entities;
using System.ComponentModel.DataAnnotations;

namespace PIISTECHLTD.Application.ViewModel;
[AutoMap(typeof(Order),ReverseMap = true)]
public class OrderVm:BaseEntity
{
    public OrderVm() => Shipments = new List<ShipmentVm>();
    public List<ShipmentVm> Shipments { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
}
