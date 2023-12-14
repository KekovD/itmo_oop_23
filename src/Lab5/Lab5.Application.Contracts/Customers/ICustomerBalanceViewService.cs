namespace Lab5.Application.Contracts.Customers;

public interface ICustomerBalanceViewService
{
    TransactionResult ViewBalance(out decimal balance);
}