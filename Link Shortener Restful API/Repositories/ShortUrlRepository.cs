using Link_Shortener_Restful_API.Data;
using Link_Shortener_Restful_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Link_Shortener_Restful_API.Repositories
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly AppDbContext _context;

        public ShortUrlRepository(AppDbContext context) { 
        _context= context;
        }

        public async Task<bool> ExistsAsync(String code) { 
        return await _context.ShortUrls.AnyAsync(x => x.UrlCode == code);
        }

        public async Task<ShortUrl?> GetByCodeAsync(String code) { 
        return await _context.ShortUrls.FirstOrDefaultAsync(x => x.UrlCode == code);
        }

        public async Task<ShortUrl?> CreateAsync(ShortUrl? shortUrl) { 
        _context.ShortUrls.Add(shortUrl);

            await _context.SaveChangesAsync();
            return shortUrl;
        }

    }
}
