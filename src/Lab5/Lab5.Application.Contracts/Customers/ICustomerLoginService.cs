namespace Lab5.Application.Contracts.Customers;

public interface ICustomerLoginService
{
    CustomerLoginResult Login(long accountId, string plainTextPassword);
}