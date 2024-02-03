using AutoMapper;
using PIISTECHLTD.SharedKernel.Common;
using PIISTECHLTD.SharedKernel.Entities;
using PIISTECHLTD.SharedKernel.Entities.Auth;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PIISTECHLTD.Application.ViewModel;
[AutoMap(typeof(Order),ReverseMap = true)]
public class OrderVm:BaseEntity
{
    [Required]
    [DisplayName("Order Date")]
    public DateTime OrderDate { get; set; }
    [Required]
    [DisplayName("Product Name")]
    public String ProductName { get; set; }
    [Required]
    public string Address { get; set; }
    public string UserId { get; set; }
    public AppUser User { get; set; }
}
