using PIISTECHLTD.Application.Repository.Base;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Application.Repository;

public interface IShipperRepository:IBaseRepository<Shipper,ShipperVm,long>
{
}
