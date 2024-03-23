using BullPerks.Services.BlpToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BullPerks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IBlpTokenService _bnbChainService;
        private readonly ILogger _logger;

        public TokenController(IBlpTokenService bnbChainService, ILogger<TokenController> logger)
        {
            _bnbChainService = bnbChainService;
            _logger = logger;
        }

        [HttpGet("token-data")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTokenData()
        {
            return Ok(await _bnbChainService.GetTokenData());
        }

        [HttpPost("save-updated-token-supply")]
        [Authorize]
        public async Task<IActionResult> SaveUpdatedTokenSupply()
        {
            try
            {
                return Ok(await _bnbChainService.SaveUpdatedTokenSupply());
            }
            catch (Exception ex)
            {
                _logger.LogError("TokenController: SaveUpdatedTokenData {Error} {StackTrace}", ex.Message, ex.StackTrace);
                return StatusCode(500, "An error occurred while updating token data.");
            }
        }
    }
}
