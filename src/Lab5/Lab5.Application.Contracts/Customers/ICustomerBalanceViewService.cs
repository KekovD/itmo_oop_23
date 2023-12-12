namespace Lab5.Application.Contracts.Customers;

public interface ICustomerBalanceViewService
{
    Task<TransactionResult> ViewBalance(out decimal balance);
}