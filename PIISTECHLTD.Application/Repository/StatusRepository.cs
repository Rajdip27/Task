using AutoMapper;
using PIISTECHLTD.Application.Repository.Base;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.Data.Persistence;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Application.Repository;

public class StatusRepository(IMapper mapper, ApplicationDbContext context) : BaseRepository<Status, StatusVm, long>(mapper, context)
{
}
