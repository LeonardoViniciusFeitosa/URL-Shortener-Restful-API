using Link_Shortener_Restful_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Link_Shortener_Restful_API.Controllers
{
    [ApiController]
    [Route("")]
    public class UrlRedirectController : ControllerBase
    {
        readonly ShortUrlService _Service;

        public UrlRedirectController(ShortUrlService service) {
            _Service = service;
        }
        [HttpGet("{code}")]
        [ProducesResponseType(301)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RedirectByCode(string code) {
            var url = await _Service.GetShortUrl(code);

            if (url is null)
            {
                return NotFound();
            }

            return Redirect(url.OriginalUrl);
        }
    }
}