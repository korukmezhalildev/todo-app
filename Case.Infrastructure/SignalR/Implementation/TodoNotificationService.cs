using Case.Infrastructure.SignalR.Abstract;
using Case.Infrastructure.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Case.Infrastructure.SignalR.Implementation;

public class TodoNotificationService : ITodoNotificationService
{
    private readonly IHubContext<TodosHub, ITodosHubClient> hubsContext;

    public TodoNotificationService(IHubContext<TodosHub, ITodosHubClient> hubsContext) => this.hubsContext = hubsContext;

    public async Task Created(Guid todoId, string title) => await hubsContext.Clients.All.Created(todoId, title , $"{todoId}'li Görev Eklendi");

    public async Task Updated(Guid todoId, string title) => await hubsContext.Clients.All.Updated(todoId, title,$"{todoId}'li Görev Güncellendi" );

    public async Task Deleted(Guid todoId, string title) => await hubsContext.Clients.All.Deleted(todoId, title, $"{todoId}'li Görev Silindi");
}