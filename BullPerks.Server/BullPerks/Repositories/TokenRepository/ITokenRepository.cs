using BullPerks.DAL.Models;
using BullPerks.Dtos;

namespace BullPerks.Repositories.TokenRepository
{
    public interface ITokenRepository
    {
        Task<List<TokenDataDto>> GetTokenData();
        Task<bool> InsertOrUpdateTokenData(TokenData token);
    }
}
