using Case.Domain.TodoModel.Enum;

namespace Case.Infrastructure.SignalR.Abstract;

public interface ITodosHubClient
{
    Task Created(Guid todoId, string title , string taskDesc);

    Task Updated(Guid todoId, string title, string taskDesc);

    Task Deleted(Guid todoId, string title, string taskDesc);
    
}