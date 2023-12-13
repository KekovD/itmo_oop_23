using Application.Models.Accounts;
using Application.Models.Users;

namespace Application.Abstractions.Repositories;

public interface ICustomerAccountsRepository
{
    Task<string?> FindAccountPasswordByAccountId(long accountId);
    Task<CustomerAccount?> FindAccountByAccountId(long accountId);
    Task CreateCustomer(User newUser, CustomerAccount newAccount, string hashedPassword);
    Task ChangeBalance(CustomerAccount account, decimal newBalance);
    Task ChangeAccountStateToClose(CustomerAccount account, DateTime closeDate);
}