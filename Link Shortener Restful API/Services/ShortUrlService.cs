using Link_Shortener_Restful_API.Entities;
using Link_Shortener_Restful_API.DTOs;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Link_Shortener_Restful_API.Data;
using Link_Shortener_Restful_API.Repositories;

namespace Link_Shortener_Restful_API.Services
{
    public class ShortUrlService
    {
        private readonly IShortUrlRepository _Repository;
        public ShortUrlService(IShortUrlRepository Repository) {
            _Repository = Repository;
        }

        public string GenerateCode() {
            const string chars =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            var random = new Random();

            return new string(
                Enumerable
                    .Repeat(chars, 6)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray()
            );
        }

        public async Task<ShortUrl> CreateShortUrl(CreateShortUrlDto dto) {
            string code;

            do {
                code = GenerateCode();
            } while (await _Repository.ExistsAsync(code));

            var url = new ShortUrl
            {
                UrlCode = code,
                OriginalUrl = dto.OriginalUrl,
                Created = DateTime.UtcNow
            };

            return await _Repository.CreateAsync(url);
        }

        public async Task<ShortUrl?> GetShortUrl(string code) {
            return await _Repository.GetByCodeAsync(code);
        }

        public async Task<bool> DeleteShortUrl(string code) {
            return await _Repository.deleteByCodeAsync(code);
        }
    }
}
