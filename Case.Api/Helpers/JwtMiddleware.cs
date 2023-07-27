using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Case.Persistance;
using Case.Persistance.Config;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Case.Api.Helpers;

public sealed class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (token is not null) await AttachUserToContext(context, token);
        await _next(context);
    }

    private async Task AttachUserToContext(HttpContext context, string token)
    {
        try
        {
            new JwtSecurityTokenHandler().ValidateToken(token, 
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            context.Items["userId"] = jwtToken.Claims.First(x => x.Type == "userId").Value;
            context.Items["email"] = jwtToken.Claims.First(x => x.Type == "email").Value;
            context.Items["name"] = jwtToken.Claims.First(x => x.Type == "name").Value;
            context.Items["surname"] = jwtToken.Claims.First(x => x.Type == "surname").Value;
        }
        catch {}
    }
}