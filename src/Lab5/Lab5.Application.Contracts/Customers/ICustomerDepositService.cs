namespace Lab5.Application.Contracts.Customers;

public interface ICustomerDepositService
{
    Task<TransactionResult> Replenishment(decimal replenishmentAmount);
}