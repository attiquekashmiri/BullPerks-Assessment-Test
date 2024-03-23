using BullPerks.DAL;
using BullPerks.DAL.Models;
using BullPerks.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BullPerks.Repositories.TokenRepository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly TokenDbContext _tokenDbContext;

        public TokenRepository(TokenDbContext tokenDbContext)
        {
                _tokenDbContext = tokenDbContext;
        }

        public async Task<List<TokenDataDto>> GetTokenData()
        {
            return await _tokenDbContext.TokenData
                .OrderByDescending (td => td.CreatedDate)
                .Select(TokenDataDto.Projection)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        } 

        public async Task<bool> InsertOrUpdateTokenData(TokenData token)
        {
            if (token != null)
            {
                await _tokenDbContext.AddAsync(token);
                await _tokenDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
