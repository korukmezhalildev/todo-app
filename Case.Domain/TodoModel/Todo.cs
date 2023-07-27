using Case.Domain.Common;
using Case.Domain.TodoModel.Enum;
using Case.Domain.UserModel;

namespace Case.Domain.TodoModel;

public sealed class Todo : BaseModel
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required TodoStatus Status { get; set; }

    public required Guid? UserId { get; set; }
    public User? User { get; set; }
    
    public IList<TodoFile>? TodoFile { get; set; }
}