using Application.Models.Accounts;
using Lab5.Application.Contracts.Customers;

namespace Lab5.Application.Customers;

internal class CurrentCustomerManager : ICurrentCustomerService
{
    public CustomerAccount? Customer { get; set; }
}