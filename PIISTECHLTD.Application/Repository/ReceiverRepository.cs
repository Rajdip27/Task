using AutoMapper;
using PIISTECHLTD.Application.Repository.Base;
using PIISTECHLTD.Application.Repositoryp;
using PIISTECHLTD.Application.ViewModel;
using PIISTECHLTD.Data.Persistence;
using PIISTECHLTD.SharedKernel.Entities;

namespace PIISTECHLTD.Application.Repository;

public class ReceiverRepository(IMapper mapper, ApplicationDbContext context) : BaseRepository<Receiver, ReceiverVm, long>(mapper, context), IReceiverRepository
{
}
