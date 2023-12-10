using Application.Models.Users;

namespace Application.Abstractions.Repositories;

public interface IUserRepository
{
     Task<User?> FindUserByUsername(string username);
}