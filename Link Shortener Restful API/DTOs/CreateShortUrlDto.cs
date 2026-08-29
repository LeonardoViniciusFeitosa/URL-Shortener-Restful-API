using System.ComponentModel.DataAnnotations;

namespace Link_Shortener_Restful_API.DTOs
{
    public class CreateShortUrlDto
    {
        [Required]
        [Url]
        public string OriginalUrl { get; set; }
    }
}
