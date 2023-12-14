using Application.Models.Accounts;

namespace Application.Abstractions.Repositories;

public interface IAdminViewOfCustomerAccountsRepository
{
    IEnumerable<CustomerAccount> GetAllCustomerAccount();
}