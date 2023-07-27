using Case.Domain.TodoModel.Enum;

namespace Case.Application.Dtos;

public record TodoDto(
    Guid Id , 
    DateTime CreatedDate, 
    DateTime? UpdatedDate , 
    Guid UserId ,
    bool IsActive, 
    string Title,
    string Description,
    TodoStatus Status
);