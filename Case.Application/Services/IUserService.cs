using Case.Application.Dtos;
using Case.Application.Repositories;
using Case.Domain.UserModel;

namespace Case.Application.Services;

public interface IUserService : IGenericRepository<User, UserDto> { }