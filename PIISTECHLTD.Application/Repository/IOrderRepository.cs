using PIISTECHLTD.Application.Repository.Base;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.Application.ViewModel.ShowDataViewModel;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Application.Repository;

public interface IOrderRepository:IBaseRepository<Order, OrderVm,long>
{
 Task<OrderTracking> GetData(string Id);
}
