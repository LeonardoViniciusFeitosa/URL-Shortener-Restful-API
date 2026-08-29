using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Link_Shortener_Restful_API.Entities
{
    [Table("ShortUrls")]
    public class ShortUrl
    {
        [Key] [Required]
        public string UrlCode { get; set; }

        [Required]
        public string OriginalUrl { get; set; }

        public DateTime? Created { get; set; }
    }
}
