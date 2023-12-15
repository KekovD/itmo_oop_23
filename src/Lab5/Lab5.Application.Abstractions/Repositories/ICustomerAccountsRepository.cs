using Application.Models.Accounts;

namespace Application.Abstractions.Repositories;

public interface ICustomerAccountsRepository
{
    string? FindAccountPasswordByAccountId(long accountId);
    CustomerAccount? FindAccountByAccountId(long accountId);
    void CreateCustomer(CustomerAccount newAccount, string hashedPassword);
    void ChangeBalance(CustomerAccount account, decimal newBalance);
    void ChangeAccountStateToClose(CustomerAccount account, DateTime closeDate);
}