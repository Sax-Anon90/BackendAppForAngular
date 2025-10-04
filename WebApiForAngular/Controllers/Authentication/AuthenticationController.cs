using CoreBusiness.Interfaces;
using Data.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiForAngular.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepositoryAsync _authenticationRepositoryAsync;
        public AuthenticationController(IAuthenticationRepositoryAsync _authenticationRepositoryAsync)
        {
            this._authenticationRepositoryAsync = _authenticationRepositoryAsync;
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthRequest authRequest)
        {
            return Ok(await _authenticationRepositoryAsync.AuthenticateUserAsync(authRequest));
        }
    }
}
