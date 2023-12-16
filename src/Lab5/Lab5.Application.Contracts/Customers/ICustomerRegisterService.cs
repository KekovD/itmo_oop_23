using Application.Models.Accounts;

namespace Lab5.Application.Contracts.Customers;

public interface ICustomerRegisterService
{
    RegisterResult Register(CustomerAccount newAccount, string plainTextPassword);
}