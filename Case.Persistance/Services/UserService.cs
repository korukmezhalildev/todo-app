using Case.Application.Dtos;
using Case.Application.Services;
using Case.Domain.UserModel;
using Case.Persistance.Context;
using Case.Persistance.Repositories;

namespace Case.Persistance.Services;

public sealed class UserService : GenericRepository<User, UserDto>, IUserService
{
    public UserService(KafeinCaseDataContext context) : base(context) {}
}
