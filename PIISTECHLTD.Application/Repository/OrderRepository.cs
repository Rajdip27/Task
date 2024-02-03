using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIISTECHLTD.Application.Repository.Base;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.Application.ViewModel.ShowDataViewModel;
using PIISTECHLTD.Data.Persistence;
using PIISTECHLTD.SharedKernel.Entities;
using PIISTECHLTD.SharedKernel.Entities.Auth;

namespace PIISTECHLTD.Application.Repository;

public class OrderRepository(IMapper mapper, ApplicationDbContext context) : BaseRepository<Order, OrderVm, long>(mapper, context), IOrderRepository
{
    public async Task<OrderTracking> GetData(string id)
    {
        var orderTracking = await (from o in context.Set<Order>()
                                   join user in context.Set<AppUser>() on o.UserId equals user.Id
                                   join ship in context.Set<Shipment>() on user.Id equals ship.UserId
                                   join shipper in context.Set<Shipper>() on ship.ShipperId equals shipper.Id
                                   join status in context.Set<Status>() on ship.StatusId equals status.Id
                                   where user.Id == id  // Add the condition here
                                   select new OrderTracking
                                   {
                                       Name = status.Name,
                                       ShipmentCost = ship.ShipmentCost,
                                       ShipmentDate = ship.ShipmentDate.ToString("d"),
                                       ConsignmentNumber = ship.ConsignmentNumber,
                                       ShipperName = shipper.ShipperName
                                   }).FirstOrDefaultAsync();

        return orderTracking;
    }


}
