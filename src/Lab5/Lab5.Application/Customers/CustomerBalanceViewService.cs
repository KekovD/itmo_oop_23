using Lab5.Application.Contracts.Customers;
using Lab5.Application.Exceptions;

namespace Lab5.Application.Customers;

internal class CustomerBalanceViewService : ICustomerBalanceViewService
{
    private readonly CurrentCustomerManager _currentCustomerManager;

    public CustomerBalanceViewService(CurrentCustomerManager currentCustomerManager)
    {
        _currentCustomerManager = currentCustomerManager;
    }

    public Task<decimal> ViewBalance()
    {
        if (_currentCustomerManager.Customer is not null)
            return Task.FromResult(_currentCustomerManager.Customer.Balance);

        throw new CurrentCustomerManagerNullException(nameof(CustomerBalanceViewService));
    }
}