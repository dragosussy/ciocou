using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;

namespace ciocou_backend.Controllers
{
    [Route("api/[controller]/event")]
    [ApiController]
    public class Ciocc : ControllerBase
    {
        private readonly EasterService _easterService;

        public Ciocc(EasterService easterService)
        {
            _easterService = easterService;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateCioccEvent([FromBody] CreateCioccEventDto cioccEventDto)
        {
            return Ok(await _easterService.SaveAsync(cioccEventDto));
        }

        [HttpPatch]
        public async Task<IActionResult> CompleteCioccEvent([FromBody] UpdateCioccEventDto updateLinkDto)
        {
            return Ok(await _easterService.UpdateAsync(updateLinkDto));
        }

        [HttpGet]
        public async Task<IActionResult> GetCioccEvent(string guid)
        {
            return Ok(await _easterService.GetCioccEvent(guid));
        }
    }
}
