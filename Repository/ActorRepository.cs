using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Repository
{
    public class ActorRepository : IActorRepository
    {
        private MovieAppDbContext _dbContext;
        public ActorRepository(MovieAppDbContext context)
        {
            _dbContext = context;
        }

        public async Task CreateActorAsync(Actor actor)
        {
            _dbContext.Actors.Add(actor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Actor?> GetActorAsync(string fullName)
        {
            return await _dbContext.Actors.FindAsync(fullName);
        }

        public async Task<List<Actor>> GetActorsAsync()
        {
            return await _dbContext.Actors.ToListAsync();
        }

        public async Task UpdateActorInfoAsync(Actor actorInfo)
        {
            _dbContext.Actors.Update(actorInfo);
            await _dbContext.SaveChangesAsync();
        }
    }
}
