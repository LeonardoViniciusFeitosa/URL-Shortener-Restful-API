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
        public async Task<ActionResult<ShortUrl>> Create(CreateShortUrlDto dto) {
            var url = await _Service.CreateShortUrl(dto);

            return CreatedAtAction(nameof(GetByCode), new { code = url.UrlCode }, url);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<ShortUrl?>> RedirectByCode(string code)
        {
            var url = await _Service.GetShortUrl(code);

            if (url is null)
            {
                return NotFound();
            }
            {
                return Redirect(url.OriginalUrl);
            }
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult> DeleteShortUrl(string code)
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
