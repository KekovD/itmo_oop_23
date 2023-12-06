using Application.Models.Accounts;

namespace Application.Abstractions.Repositories;

public interface IAdminAccountsRepository
{
    string? FindAdminPasswordById(long userId);
    IEnumerable<CustomerAccount> GetAllCustomerAccount();
}