using ciocou_backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ciocou_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ciocc : ControllerBase
    {
        private readonly EasterService _easterService;

        public Ciocc(EasterService easterService)
        {
            _easterService = easterService;
        }

        [HttpPost("link")]
        public async Task<IActionResult> GenerateCioccLink(string user1Name)
        {
            ////var link = Link.GenerateLink(user1Name, DateTime.Now.AddMonths(1));
            ////var c = CioccEvent.builder().Winner(link).Build();
            ////try
            ////{
            ////    await _repository.Links.AddAsync(link);
            ////    await _repository.SaveChangesAsync();
            ////}
            ////catch (Exception)
            ////{
            ////    return Problem("database communication problem.");
            ////}

            ////return Ok(link.ToUrlFormat(_configuration.GetValue<string>("DomainUrl")));\
            var ciocc = CioccEvent.builder().UserName1("haha").Build();
            var res = await _easterService.SaveAsync(ciocc);
            return Ok(res.UserName1);
        }


        //[HttpPatch]
        //public async Task<IActionResult> UpdateCioccLink([FromBody] UpdateCioccEventDto updateLinkDto)
        //{
        //    var link = _repository.Links.FirstOrDefault(l => l.Guid == updateLinkDto.Guid);
        //    if (link == null)
        //        return BadRequest("invalid link.");

        //    try
        //    {
        //        link.UpdateLink(updateLinkDto.User2Name, updateLinkDto.Winner);
        //        _repository.Links.Update(link);
        //        await _repository.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return Problem("database communication problem.");
        //    }

        //    return Ok(link);
        //}

        //[HttpGet("link")]
        //public async Task<IActionResult> GetCioccLink(string guid)
        //{
        //    return Ok(await _repository.Links.FirstOrDefaultAsync(l => l.Guid == guid));
        //}
    }
}
