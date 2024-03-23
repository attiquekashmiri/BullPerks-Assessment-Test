using BullPerks.Dtos;
using BullPerks.Services.Account;
using Microsoft.AspNetCore.Mvc;

namespace BullPerks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto model)
        {
            var token = _accountService.LoginUser(model);
            return Ok(new { Token = token });
        }
    }
}
