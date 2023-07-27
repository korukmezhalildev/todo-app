using System.ComponentModel.DataAnnotations;
using Case.Domain.Common;

namespace Case.Domain.UserModel;

public sealed class User : BaseModel
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    [EmailAddress]
    public required string EMail { get; set; }
    public required string Password { get; set; }
}