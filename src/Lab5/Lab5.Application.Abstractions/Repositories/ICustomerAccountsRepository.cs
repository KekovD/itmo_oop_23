using Application.Models.Accounts;

namespace Application.Abstractions.Repositories;

public interface ICustomerAccountsRepository
{
    string? FindAccountPasswordById(long userId, long accountId);
    CustomerAccount? FindAccountById(long userId, decimal accountId);
}