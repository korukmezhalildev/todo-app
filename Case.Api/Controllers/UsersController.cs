using Case.Api.Helpers;
using Case.Application.Dtos;
using Case.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Case.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[CustomAuthorize]
public sealed class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync() => Ok(await _userService.GetListAsync());
    
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id) => Ok(await _userService.GetAsync(id)); 
    
    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync(UserDto dto) => Ok(await _userService.CreateAsync(dto));
    
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync(UserDto dto) => Ok(await _userService.CreateAsync(dto));
    
    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAsync(UserDto dto) => Ok(await _userService.CreateAsync(dto));
}