using Case.Domain.Common;

namespace Case.Domain.TodoModel;

public sealed class TodoFile : BaseModel
{
    public required Guid TodoId { get; set; }
    public required string Path { get; set; }
    public Todo Todo { get; set; }
}