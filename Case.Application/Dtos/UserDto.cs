namespace Case.Application.Dtos;

public record UserDto(
    Guid Id , 
    DateTime CreatedDate, 
    DateTime? UpdatedDate , 
    bool IsActive, 
    string Name,
    string Surname,
    string EMail
);