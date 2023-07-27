using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Case.Application.Dtos;
using Case.Application.Repositories;
using Case.Application.Services;
using Case.Domain.UserModel;
using Case.Persistance.Config;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Case.Persistance.Services;

public sealed class TokenService : ITokenService
{
    private readonly IGenericRepository<User, UserDto> _generic;
    private readonly AppSettings _appSettings;

    public TokenService(IGenericRepository<User, UserDto> generic, IOptions<AppSettings> appSettings)
    {
        _generic = generic;
        _appSettings = appSettings.Value;
    }

    public async Task<string> Login(LoginDto dto)
    {
        var user = await _generic.GetAsync(x => x.EMail == dto.email && x.Password == dto.password);

        return user is not null
            ? GenerateJwtToken(user)
            : null;
    }
    
    private string GenerateJwtToken(UserDto user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] 
            { 
                new Claim("userId", user.Id.ToString()),
                new Claim("email",user.EMail),
                new Claim("name",user.Name),
                new Claim("surname",user.Surname),
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}