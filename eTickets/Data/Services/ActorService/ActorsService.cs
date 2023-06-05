using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services.ActorService
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {

        public ActorsService(AppDbContext context) : base(context) { }

    }
}
