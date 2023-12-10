using Application.Models.Users;

namespace Application.Abstractions.Repositories;

public interface IUserRepository
{
     Task<User?> FindUserByUsername(string username);
     Task<long?> FindIdByUsername(string username);
     Task CreateUser(User newUser);
}