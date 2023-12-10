using Application.Models.Accounts;
using Workshop5.Application.Contracts.Customers;

namespace Lab5.Application.Customers;

internal class CurrentCustomerManager : ICurrentCustomerService
{
    public CustomerAccount? Customer { get; set; }
}