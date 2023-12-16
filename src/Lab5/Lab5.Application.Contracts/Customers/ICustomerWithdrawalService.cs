namespace Lab5.Application.Contracts.Customers;

public interface ICustomerWithdrawalService
{
    TransactionResult Withdrawal(decimal replenishmentAmount);
}