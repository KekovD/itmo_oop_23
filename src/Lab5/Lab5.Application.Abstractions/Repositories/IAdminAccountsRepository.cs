using Application.Models.Accounts;

namespace Application.Abstractions.Repositories;

public interface IAdminAccountsRepository
{
    AdminAccount? FindAccountByAccountId(long accountId);
    string? FindAdminPasswordByAccountId(long accountId);
    void AddAdmin(AdminAccount adminAccount, string hashedPassword);
}