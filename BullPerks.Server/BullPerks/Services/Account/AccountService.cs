using BullPerks.Dtos;
using BullPerks.Helpers;
using System.Text;

namespace BullPerks.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly byte[] _key;
        public AccountService(IConfiguration configuration)
        {
            _configuration = configuration;
            var secretKey = _configuration["Jwt:SecretKey"];
            _key = !string.IsNullOrEmpty(secretKey) ? Encoding.ASCII.GetBytes(secretKey) : throw new InvalidOperationException("JWT secret key is missing in configuration");

        }

        public string LoginUser(LoginDto loginDto)
        {
            //As per required to generate only token, Assuming authentication is successful
            AuthHelper authHelper = new AuthHelper();

            return authHelper.GenerateJwtToken(loginDto.UserName, _key);
        }



    }
}
