namespace Lab5.Application.Contracts.Customers;

public interface ICustomerLoginService
{
    Task<LoginResult> Login(long accountId, string plainTextPassword);
}