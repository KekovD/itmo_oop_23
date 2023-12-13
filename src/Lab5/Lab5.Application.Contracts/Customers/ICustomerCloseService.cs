namespace Lab5.Application.Contracts.Customers;

public interface ICustomerCloseService
{
    Task<CloseResult> DeleteAccount(string plainTextPassword);
}