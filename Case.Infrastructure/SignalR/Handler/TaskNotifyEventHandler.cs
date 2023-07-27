using Case.Infrastructure.SignalR.Abstract;
using Case.Infrastructure.SignalR.Enum;
using Case.Infrastructure.SignalR.Events;
using MediatR;

namespace Case.Infrastructure.SignalR.Handler;

public sealed class TaskNotifyEventHandler  : IRequestHandler<TaskNotifyEvent>
{
    private readonly ITodoNotificationService _notificationService;

    public TaskNotifyEventHandler(ITodoNotificationService notificationService) => _notificationService = notificationService;

    public async Task Handle(TaskNotifyEvent request, CancellationToken cancellationToken)
    {
        switch (request.state)
        {
            case NotifyState.Created:
                await _notificationService.Created(request.dto.Id, request.dto.Title);
            break;
            case NotifyState.Deleted:
                await _notificationService.Deleted(request.dto.Id, request.dto.Title);
            break;
            case NotifyState.Updated:
                await _notificationService.Updated(request.dto.Id, request.dto.Title);
            break;
        }
    }
}