using Application.Models.Accounts;
using Application.Models.Users;

namespace Lab5.Application.Contracts.Customers;

public interface ICustomerRegisterService
{
    Task<RegisterResult> Register(User user, CustomerAccount newAccount, string plainTextPassword);
}