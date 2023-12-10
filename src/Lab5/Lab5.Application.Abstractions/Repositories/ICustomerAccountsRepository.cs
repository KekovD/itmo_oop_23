using Application.Models.Accounts;

namespace Application.Abstractions.Repositories;

public interface ICustomerAccountsRepository
{
    Task<string?> FindAccountPasswordByAccountId(long accountId);
    Task<CustomerAccount?> FindAccountByAccountId(long accountId);
}