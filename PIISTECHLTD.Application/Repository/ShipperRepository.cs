using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIISTECHLTD.Application.Repository.Base;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.Data.Persistence;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Application.Repository;

public class ShipperRepository(IMapper mapper, ApplicationDbContext context) : BaseRepository<Shipper, ShipperVm, long>(mapper, context),IShipperRepository
{
}
