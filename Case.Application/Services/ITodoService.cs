using Case.Application.Dtos;
using Case.Application.Repositories;
using Case.Domain.TodoModel;

namespace Case.Application.Services;

public interface ITodoService : IGenericRepository<Todo, TodoDto>
{
}