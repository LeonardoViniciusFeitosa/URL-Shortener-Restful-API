using Link_Shortener_Restful_API.DTOs;
using Link_Shortener_Restful_API.Entities;
using Link_Shortener_Restful_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Link_Shortener_Restful_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShortUrlController : ControllerBase
    {

        private readonly ShortUrlService _Service;

        public ShortUrlController(ShortUrlService service) { 
        _Service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ShortUrl>> CreateAsync(CreateShortUrlDto dto) {
            var url = await _Service.CreateShortUrl(dto);

            return CreatedAtAction(nameof(GetByCodeAsync), new { code = url.UrlCode }, url);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<ShortUrl?>> GetByCodeAsync(string code)
        {
            var url = await _Service.GetShortUrl(code);

            if (url is null)
            {
                return NotFound();
            }
            return Ok(url);
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult<bool>> DeleteShortUrl(string code)
        {
            var result = await _Service.DeleteShortUrl(code);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
