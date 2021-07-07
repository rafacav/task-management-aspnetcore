using Common.DTO.Auth;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using Service.Auth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Interface.Controllers
{
    [Route("Auth")]
    public class AuthController : ControllerBase
    {
        private readonly IOpenIddictApplicationManager _applicationManager;
        private readonly AuthService _authService;

        public AuthController(IOpenIddictApplicationManager applicationManager, AuthService authService)
        {
            _applicationManager = applicationManager;
            _authService = authService;
        }

        [HttpPost("SignIn"), Produces("application/json")]
        public IActionResult Exchange()
        {
            var request = HttpContext.GetOpenIddictServerRequest();
            if (request.IsPasswordGrantType())
            {
                var user = _authService.GetByUsername(request.Username);

                if (user == null || user.Password != request.Password)
                {
                    return Forbid(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
                }
                
                var identity = new ClaimsIdentity(
                    OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
                    Claims.Name,
                    Claims.Role);

                identity.AddClaim(Claims.Subject,
                    "UserSubject",
                    Destinations.AccessToken);

                identity.AddClaim(Claims.Name, user.Username,
                    Destinations.AccessToken); ;
                
                var principal = new ClaimsPrincipal(identity);
                
                return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            throw new InvalidOperationException("The specified grant type is not supported.");
        }

        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp(AuthCreateDto authCreateDto)
        {
            return Ok(_authService.SignUp(authCreateDto));
        }
    }
    
}
