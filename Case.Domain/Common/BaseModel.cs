namespace Case.Domain.Common;

public abstract class BaseModel
{
    public required Guid Id { get; set; } = new Guid();
    public required DateTime CreatedDate { get; set; } = DateTime.Now;
    public required bool IsActive { get; set; } = true;
    public DateTime? UpdatedDate { get; set; }
}