using Application.Models.Accounts;

namespace Application.Abstractions.Repositories;

public interface IAdminViewOfCustomerAccountsRepository
{
    IAsyncEnumerable<CustomerAccount> GetAllCustomerAccount();
}