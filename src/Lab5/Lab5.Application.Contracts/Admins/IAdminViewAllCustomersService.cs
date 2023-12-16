using Application.Models.Accounts;

namespace Lab5.Application.Contracts.Admins;

public interface IAdminViewAllCustomersService
{
    IEnumerable<CustomerAccount> ViewAllCustomers();
}