using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Lab5.Application.Contracts.Admins;

namespace Lab5.Application.Admins;

public class AdminViewAllCustomersService : IAdminViewAllCustomersService
{
    private readonly IAdminViewOfCustomerAccountsRepository _repository;

    public AdminViewAllCustomersService(IAdminViewOfCustomerAccountsRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<CustomerAccount> ViewAllCustomers() => _repository.GetAllCustomerAccount();
}