namespace Lab5.Application.Contracts.Customers;

public interface ICustomerLoginService
{
    Task<CustomerLoginResult> Login(long accountId, string plainTextPassword);
}