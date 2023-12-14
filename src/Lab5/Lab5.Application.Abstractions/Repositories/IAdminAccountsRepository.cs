using Application.Models.Accounts;
using Application.Models.Users;

namespace Application.Abstractions.Repositories;

public interface IAdminAccountsRepository
{
    AdminAccount? FindAccountByAccountId(long accountId);
    string? FindAdminPasswordByAccountId(long accountId);
    void AddAdmin(User newUser, AdminAccount adminAccount, string hashedPassword);
}