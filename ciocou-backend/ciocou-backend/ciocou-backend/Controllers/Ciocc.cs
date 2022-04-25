using ciocou_backend.DbContext;
using ciocou_backend.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ciocou_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ciocc : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Repository _repository;

        public Ciocc(Repository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpGet("generate")]
        public async Task<IActionResult> GenerateCioccLink(string user1Name)
        {
            var link = Link.GenerateLink(user1Name, DateTime.Now.AddMonths(1));

            try
            {
                await _repository.Links.AddAsync(link);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Problem("database communication problem.");
            }

            return Ok(link.ToUrlFormat(_configuration.GetValue<string>("DomainUrl")));
        }


        [HttpPost("cioccneste")]
        public async Task<IActionResult> UpdateCioccLink([FromBody] UpdateCioccLinkDto updateLinkDto)
        {
            var link = _repository.Links.FirstOrDefault(l => l.Guid == updateLinkDto.Guid);
            if (link == null)
                return BadRequest("invalid link.");

            try
            {
                link.UpdateLink(updateLinkDto.User2Name, updateLinkDto.Winner);
                _repository.Links.Update(link);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Problem("database communication problem.");
            }

            return Ok(link);
        }

        [HttpGet("get-link")]
        public async Task<IActionResult> GetCioccLink(string guid)
        {
            return Ok(await _repository.Links.FirstOrDefaultAsync(l => l.Guid == guid));
        }
    }
}
