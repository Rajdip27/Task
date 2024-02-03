using AutoMapper;
using PIISTECHLTD.SharedKernel.Common;
using PIISTECHLTD.SharedKernel.Entities;
using System.ComponentModel;

namespace PIISTECHLTD.Application.ViewModel;
[AutoMap(typeof(Status),ReverseMap =true)]
public class StatusVm:BaseEntity
{
    [DisplayName("Status")]
    public string Name { get; set; } = string.Empty;
}
