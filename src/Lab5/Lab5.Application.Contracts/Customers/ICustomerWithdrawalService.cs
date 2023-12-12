namespace Lab5.Application.Contracts.Customers;

public interface ICustomerWithdrawalService
{
    Task<TransactionResult> Withdrawal(decimal replenishmentAmount);
}