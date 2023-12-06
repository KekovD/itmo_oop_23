using Application.Models.Users;

namespace Application.Abstractions.Repositories;

public interface IUserRepository
{
    User? FindUserByUsername(string username);
}