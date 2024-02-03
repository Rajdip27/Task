using AutoMapper;
using PIISTECHLTD.Application.Repository.Base;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.Data.Persistence;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Application.Repository;

public class ShipmentRepository(IMapper mapper, ApplicationDbContext context) : BaseRepository<Shipment, ShipmentVm, long>(mapper, context),IShipmentRepository
{
}
