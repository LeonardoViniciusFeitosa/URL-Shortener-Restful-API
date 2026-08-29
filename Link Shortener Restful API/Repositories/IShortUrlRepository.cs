using Link_Shortener_Restful_API.Entities;

namespace Link_Shortener_Restful_API.Repositories
{
    public interface IShortUrlRepository
    {
        Task<bool> ExistsAsync(string code);
        Task<ShortUrl?> GetByCodeAsync(string code);
        Task<ShortUrl?> CreateAsync(ShortUrl shortUrl);
    }
}
