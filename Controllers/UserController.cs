using Microsoft.AspNetCore.Mvc;
using NoSQL_MongoDb.Models;
using NoSQL_MongoDb.Services;

namespace NoSQL_MongoDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly MongoDbService _monoDbService;
        public UserController(MongoDbService monoDbService)
        {
            _monoDbService = monoDbService;
        }
        [HttpGet]
        public async Task<List<Team>> GetAll() => await _monoDbService.GetAsync();

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            var team = await _monoDbService.GetByIdAsync(Id);
            if (team == null) return NotFound();
            return Ok(team);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Team team)
        {
            await _monoDbService.CreateAsync(team);
            return CreatedAtAction(nameof(GetById), new { id = team.Id }, team);
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update (string Id, Team team)
        {
            var teamUpdate = await _monoDbService.GetByIdAsync(Id);
            if (teamUpdate is null)
            {
                return NotFound();
            }
            team.Id = teamUpdate.Id;
            await _monoDbService.UpdateAsync(Id, team);
            return Ok();
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var teamUpdate = await _monoDbService.GetByIdAsync(Id);
            if (teamUpdate is null)
            {
                return NotFound();
            }
           
            await _monoDbService.DeleteAsync(Id);
            return Ok();
        }
    }
} 
