using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIISTECHLTD.Application.Repository.Base;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.Data.Persistence;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Application.Repository;

public class OrderRepository(IMapper mapper, ApplicationDbContext context) : BaseRepository<Order, OrderVm, long>(mapper, context), IOrderRepository
{
}
