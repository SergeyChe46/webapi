using webapi.Models;

namespace webapi.Repository
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetActorsAsync();
        Task<Actor> GetActorAsync(string fullName);
        Task CreateActorAsync(Actor actor);
        Task UpdateActorInfoAsync(Actor actorInfo);
    }
}
