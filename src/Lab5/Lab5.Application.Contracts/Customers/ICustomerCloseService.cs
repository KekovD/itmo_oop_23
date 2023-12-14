namespace Lab5.Application.Contracts.Customers;

public interface ICustomerCloseService
{
    CloseResult DeleteAccount(string plainTextPassword);
}