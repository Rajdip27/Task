using PIISTECHLTD.Application.Repository.Base;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Application.Repository;

public interface IOrderRepository:IBaseRepository<Order, OrderVm,long>
{
}
