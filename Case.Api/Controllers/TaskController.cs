using Case.Api.Helpers;
using Case.Application.Dtos;
using Case.Application.Services;
using Case.Infrastructure.SignalR.Enum;
using Case.Infrastructure.SignalR.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Case.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[CustomAuthorize]
public sealed class TaskController : Controller
{
    private readonly ITodoService _todoService;
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _context;
    public TaskController(ITodoService todoService, IMediator mediator, IHttpContextAccessor context)
    {
        _todoService = todoService;
        _mediator = mediator;
        _context = context;
        
    }
    [HttpGet("GetAllTask")]
    public async Task<IActionResult> GetAllAsync() => 
        Ok(await _todoService.GetListAsync());
    
    [HttpGet("GetByIdTask")]
    public async Task<IActionResult> GetByIdAsync(Guid id) => 
        Ok(await _todoService.GetAsync(id)); 
    
    [HttpGet("GetTaskByUserId")]
    public async Task<IActionResult> GetTaskByUserIdAsync(Guid id) => 
        Ok(await _todoService.GetAsync(x => x.UserId == id)); 
    
    [HttpGet("GetUserTaskByStatus")]
    public async Task<IActionResult> GetUserTaskByStatusAsync(Guid userId, byte status) => 
        Ok(await _todoService.GetAsync(x => x.UserId == userId && (byte)x.Status == status)); 
    
    [HttpPost("CreateTask")]
    public async Task<IActionResult> CreateAsync(TodoDto dto)
    {
        if (await _todoService.CreateAsync(dto)) 
        { 
            await _mediator.Publish(new TaskNotifyEvent(dto, NotifyState.Created)); 
            return Ok();
        }
        return BadRequest("Failed to create the task.");
    }

    [HttpDelete("DeleteTask")]
    public async Task<IActionResult> DeleteAsync(TodoDto dto)
    {
        if (IdentityHelper.GetUserId(_context.HttpContext) == dto.UserId)
        {
            if (await _todoService.RemoveAsync(dto))
            {
                await _mediator.Publish(new TaskNotifyEvent(dto, NotifyState.Deleted));
                return Ok();
            }
            return BadRequest("Failed to delete the task.");
        }

        return BadRequest("User identity mismatch.");
    }

    [HttpPut("UpdateTask")]
    public async Task<IActionResult> UpdateAsync(TodoDto dto)
    {
        if (IdentityHelper.GetUserId(_context.HttpContext) == dto.UserId)
        {
            if (await _todoService.UpdateAsync(dto))
            {
                await _mediator.Publish(new TaskNotifyEvent(dto, NotifyState.Updated));
                return Ok();
            }
            return BadRequest("Failed to update the task.");
        }
        return BadRequest("User identity mismatch.");
    }
}