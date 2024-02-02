using AutoMapper;
using PIISTECHLTD.SharedKernel.Common;
using PIISTECHLTD.SharedKernel.Entities;
using System.ComponentModel.DataAnnotations;

namespace PIISTECHLTD.Application.ViewModel;
[AutoMap(typeof(Shipment), ReverseMap = true)]
public class ShipmentVm:BaseEntity
{
    [Required]
    public long ShipperId { get; set; }
    public ShipperVm Shipper { get; set; }
    [Required]
    public long ReceiverId { get; set; }
    public ReceiverVm Receiver { get; set; }
    [Required]
    public DateTime ShipmentDate { get; set; }
    [Required]
    public decimal ShipmentCost { get; set; }
    [Required]
    public ShipmentStatus Status { get; set; }
    [Required]
    public string ConsignmentNumber { get; set; }
}
