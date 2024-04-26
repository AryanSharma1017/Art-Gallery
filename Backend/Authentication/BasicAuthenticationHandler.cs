using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using art_gallery.Services;
using art_gallery.Models;
using Scrypt;

namespace art_gallery.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        
        public UserService _U;

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions>options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, UserService US ) : base(options, logger, encoder, clock)
        {
            _U = US;
        }


        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var Endpoint_MD = Context.GetEndpoint();

            if(Endpoint_MD?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return AuthenticateResult.NoResult();
            }


            base.Response.Headers.Add("WWW-Authenticate", @"Basic realm=""Access to the Art Gallery.""");

            var authHeader = base.Request.Headers["Authorization"].ToString();

            if(string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Basic "))
            {
                return AuthenticateResult.Fail("Check again");
            }

            var Cred = authHeader.Substring("Basic ".Length).Trim();

            var Credentials = Encoding.UTF8.GetString(Convert.FromBase64String(Cred));

            var parts = Credentials.Split(':' , 2);

            if(parts.Length != 2)
            {
                return AuthenticateResult.Fail("Invalid format ");   
            }


            var Email_Part = parts[0];
            var Pass_Part = parts[1];

            var user = await _U.GetUserByEmail(Email_Part);

            if(user == null)
            {
                Response.StatusCode = 401;
                return AuthenticateResult.Fail("Authentication is failed, check the credentials entered");
            }

            var scrypt = new ScryptEncoder();

            if (scrypt.Compare(Pass_Part, user.PasswordHash))
            {
                var claims = new[]
                {
                    new Claim("name", $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Role, user.Role ?? ""),
                    new Claim(ClaimTypes.Role, user.Description ?? "")
                };

                var identity = new ClaimsIdentity(claims, "Basic");
                var claimsPrincipal = new ClaimsPrincipal(identity);
                var authTicket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

                Response.StatusCode = 200;
                return AuthenticateResult.Success(authTicket);
            }

            else if(!scrypt.Compare(Pass_Part, user.PasswordHash))
            {
                Response.StatusCode = 401;
                return AuthenticateResult.Fail("Incorrect Password");
            }

            else
            {
                Response.StatusCode = 401;
                return AuthenticateResult.Fail("Authentication failed");
            }
        }
    }
}