using Case.Application.Dtos;
using Case.Application.Services;
using Case.Domain.TodoModel;
using Case.Persistance.Context;
using Case.Persistance.Repositories;

namespace Case.Persistance.Services;

public sealed class TodoService : GenericRepository<Todo, TodoDto>, ITodoService
{
    public TodoService(KafeinCaseDataContext context) : base(context) {}
}
