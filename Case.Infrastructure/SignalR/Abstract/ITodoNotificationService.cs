using Case.Domain.TodoModel.Enum;

namespace Case.Infrastructure.SignalR.Abstract;

public interface ITodoNotificationService
{
    Task Created(Guid todoId, string title );

    Task Updated(Guid todoId, string title );

    Task Deleted(Guid todoId, string title);
}