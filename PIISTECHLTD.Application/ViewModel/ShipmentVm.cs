using AutoMapper;
using PIISTECHLTD.SharedKernel.Common;
using PIISTECHLTD.SharedKernel.Entities;
using PIISTECHLTD.SharedKernel.Entities.Auth;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PIISTECHLTD.Application.ViewModel;
[AutoMap(typeof(Shipment), ReverseMap = true)]
public class ShipmentVm:BaseEntity
{
    [DisplayName("Shipper Name")]
    public long ShipperId { get; set; }
    public ShipperVm Shipper { get; set; }
    [Required]
    [DisplayName("Receiver Name")]
    public long ReceiverId { get; set; }
    public ReceiverVm Receiver { get; set; }
    [Required]
    [DisplayName("Shipment Date")]
    public DateTime ShipmentDate { get; set; }
    [Required]
    [DisplayName("Shipment Cost")]
    public decimal ShipmentCost { get; set; }
    [DisplayName("Status")]
    public long StatusId { get; set; }
    public StatusVm Status { get; set; }
    public string UserId { get; set; }
    public AppUser AppUser { get; set; }
    [Required]
    [DisplayName("Consignment Number")]
    public string ConsignmentNumber { get; set; }= $"CO-{DateTime.Now:yyyyMMdd}-{new Random().Next(10000, 99999)}";
}
