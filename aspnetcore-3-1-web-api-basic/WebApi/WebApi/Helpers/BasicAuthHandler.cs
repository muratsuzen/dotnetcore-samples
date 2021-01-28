using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Helpers
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService _userService;

        public BasicAuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            User user = null;
            StringValues values;
            if (!Request.Headers.TryGetValue("Authorization", out values))
            {
                return AuthenticateResult.Fail("Authorization Header Bulunmamaktadır");
            }

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(values.First());
                var tokenBytes = Convert.FromBase64String(authHeader.Parameter);
                var tokenSplit = Encoding.UTF8.GetString(tokenBytes).Split(new[] { ':' }, 2);
                var username = tokenSplit[0];
                var password = tokenSplit[1];
                user = _userService.Authenticate(username, password);
            }
            catch
            {
                return AuthenticateResult.Fail("Geçersiz Authorization Header");
            }

            if (user == null)
                return AuthenticateResult.Fail("Kullanıcı adı yada şifre geçersiz");

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
