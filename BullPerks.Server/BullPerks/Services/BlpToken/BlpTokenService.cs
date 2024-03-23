using BullPerks.DAL.Models;
using BullPerks.Dtos;
using BullPerks.Helpers;
using BullPerks.Repositories.TokenRepository;
using Nethereum.Web3;
using System.Numerics;
namespace BullPerks.Services.BlpToken;

public class BlpTokenService : IBlpTokenService
{
    private readonly ITokenRepository _tokenRepository;
    private readonly IConfiguration _configuration;
    private readonly BlpTokenHelper _blpTokenHelper;
    private readonly string[] _nonCirculatingAddresses;
    private readonly string _tokenAddress;

    public BlpTokenService(ITokenRepository tokenRepository, IConfiguration configuration)
    {

        _tokenRepository = tokenRepository;
        _configuration = configuration;

        string web3Url = _configuration["Web3Url"] ?? throw new InvalidOperationException("Web3Url is missing in appsettings.json");
        string abi = _configuration.GetValue<string>("Abi") ?? throw new InvalidOperationException("Abi is missing in appsettings.json");
        _tokenAddress = _configuration["TokenAddress"] ?? throw new InvalidOperationException("TokenAddress is missing in appsettings.json");
        _nonCirculatingAddresses = _configuration.GetSection("NonCirculatingAddresses").Get<string[]>() ?? throw new InvalidOperationException("NonCirculatingAddresses are missing in appsettings.json");

        _blpTokenHelper = new BlpTokenHelper(web3Url, abi, _tokenAddress);
    }

    public async Task<bool> SaveUpdatedTokenSupply()
    {
        var tokenData = await GetUpdatedTokenData();
        return await SaveTokenData(tokenData);
    }

    public async Task<List<TokenDataDto>> GetTokenData() => await _tokenRepository.GetTokenData();

    #region Private Methods
    private async Task<TokenData> GetUpdatedTokenData()
    {
        var totalSupply = await _blpTokenHelper.GetTotalSupplyAsync();
        var nonCirculatingSupply = await _blpTokenHelper.GetNonCirculatingSupplyAsync(_nonCirculatingAddresses);
        var circulatingSupply = totalSupply - nonCirculatingSupply;
        return new TokenData()
        {
            Name = _tokenAddress,
            TotalSupply = totalSupply.ToString(),
            CirculatingSupply = circulatingSupply.ToString(),
            CreatedDate = DateTime.UtcNow
        };
    }

    private async Task<bool> SaveTokenData(TokenData tokenData)
    {
        return await _tokenRepository.InsertOrUpdateTokenData(tokenData);
    }
    #endregion



}


