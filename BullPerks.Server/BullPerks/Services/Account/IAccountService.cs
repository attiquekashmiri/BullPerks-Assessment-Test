using BullPerks.Dtos;

namespace BullPerks.Services.Account
{
    public interface IAccountService
    {
        string LoginUser(LoginDto loginDto);
    }
}
