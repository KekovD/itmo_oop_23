using Application.Models.Accounts;

namespace Application.Abstractions.Repositories;

public interface IAdminAccountsRepository
{
    Task<AdminAccount?> FindAccountByAccountId(long accountId);
    Task<string?> FindAdminPasswordByAccountId(long accountId);
}