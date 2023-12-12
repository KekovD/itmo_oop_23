namespace Lab5.Application.Contracts.Customers;

public interface ICustomerBalanceViewService
{
    Task<decimal> ViewBalance();
}