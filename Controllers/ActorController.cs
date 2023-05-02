using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using webapi.MappingConfiguration;
using webapi.Models;
using webapi.Repository;

namespace webapi.Controllers
{
    [Route("[controller]/{action}")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;
        private readonly Logger _logger;

        public ActorController(IActorRepository actorRepository) 
        {
            _actorRepository = actorRepository;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [HttpGet]
        public async Task<List<Actor>> GetActors()
        {
            return await _actorRepository.GetActorsAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor([FromBody] ActorViewModel actor)
        {
            if (actor == null)
            {
                _logger.Info("Actor was null");
                return BadRequest(ModelState);
            }

            var mapper = ActorMapping.InitializeMapping();
            var newActor = mapper.Map<Actor>(actor);

            await _actorRepository.CreateActorAsync(newActor);
            _logger.Info($"{newActor} was added successfully");
            return Ok(newActor);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActor(int  actorId, [FromBody] ActorViewModel actorInfo)
        {
            if (actorInfo == null)
            {
                _logger.Info("Actor info was null");
                return BadRequest(ModelState);
            }

            var currentActorInfo = await _actorRepository.GetActorAsync(actorInfo.Name);
            if (currentActorInfo == null)
            {
                return BadRequest("Actor wasn't found. Try add new");
            }

            var mapper = ActorMapping.InitializeMapping();
            var newActorInfo = mapper.Map<Actor>(actorInfo);
            await _actorRepository.UpdateActorInfoAsync(newActorInfo);
            return Ok(newActorInfo);
        }
    }
}
