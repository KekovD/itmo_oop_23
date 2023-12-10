using Application.Models.Accounts;

namespace Workshop5.Application.Contracts.Customers;

public interface ICurrentCustomerService
{
    CustomerAccount? Customer { get; }
}