using Case.Application.Dtos;
using Case.Infrastructure.SignalR.Enum;
using MediatR;

namespace Case.Infrastructure.SignalR.Events;

public sealed record TaskNotifyEvent(TodoDto dto, NotifyState state)  : IRequest;