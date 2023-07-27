using AutoMapper;
using Case.Application.Dtos;
using Case.Domain.TodoModel;
using Case.Domain.UserModel;

namespace Case.Application.AutoMapper;

public sealed class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User,UserDto>().ReverseMap();
        CreateMap<Todo,TodoDto>().ReverseMap();
    }
}