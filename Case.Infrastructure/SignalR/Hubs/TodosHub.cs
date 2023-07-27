using Case.Infrastructure.SignalR.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Case.Infrastructure.SignalR.Hubs;

[Authorize]
public sealed class TodosHub : Hub<ITodosHubClient> { }