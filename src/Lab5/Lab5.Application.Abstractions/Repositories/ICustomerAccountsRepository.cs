using Application.Models.Accounts;
using Application.Models.Users;

namespace Application.Abstractions.Repositories;

public interface ICustomerAccountsRepository
{
    string? FindAccountPasswordByAccountId(long accountId);
    CustomerAccount? FindAccountByAccountId(long accountId);
    void CreateCustomer(User newUser, CustomerAccount newAccount, string hashedPassword);
    void ChangeBalance(CustomerAccount account, decimal newBalance);
    void ChangeAccountStateToClose(CustomerAccount account, DateTime closeDate);
}