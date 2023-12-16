namespace Lab5.Application.Contracts.Customers;

public interface ICustomerDepositService
{
    TransactionResult Replenishment(decimal replenishmentAmount);
}