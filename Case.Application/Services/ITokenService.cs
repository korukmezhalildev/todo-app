using Case.Application.Dtos;

namespace Case.Application.Services;

public interface ITokenService
{
    Task<string> Login(LoginDto dto);

}