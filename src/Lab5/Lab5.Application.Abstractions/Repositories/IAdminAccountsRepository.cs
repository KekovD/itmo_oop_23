namespace Application.Abstractions.Repositories;

public interface IAdminAccountsRepository
{
    Task<string?> FindAdminPasswordByAccountId(long userId, long accountId);
}