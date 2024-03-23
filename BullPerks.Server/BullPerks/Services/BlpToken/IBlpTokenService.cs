using BullPerks.Dtos;

namespace BullPerks.Services.BlpToken
{
    public interface IBlpTokenService
    {
        /// <summary>
        /// Save latest data of token supply
        /// </summary>
        /// <returns>True for Success and False for Failure</returns>
        Task<bool> SaveUpdatedTokenSupply();
        Task<List<TokenDataDto>> GetTokenData();
    }
}
