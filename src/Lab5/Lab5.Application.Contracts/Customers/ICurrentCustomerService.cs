using Application.Models.Accounts;

namespace Lab5.Application.Contracts.Customers;

public interface ICurrentCustomerService
{
    CustomerAccount? Customer { get; }
}