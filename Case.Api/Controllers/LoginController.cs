using Case.Application.Dtos;
using Case.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Case.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : Controller
{
    private readonly ITokenService _tokenService;
    public LoginController(ITokenService tokenService) => _tokenService = tokenService;

    [HttpGet("Login")]
    public async Task<IActionResult> GetAllAsync(LoginDto dto) => Ok(await _tokenService.Login(dto));
}