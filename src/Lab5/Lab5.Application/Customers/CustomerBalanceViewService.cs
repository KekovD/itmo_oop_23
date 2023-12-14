using Application.Models.Accounts;
using Lab5.Application.Contracts;
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

    public TransactionResult ViewBalance(out decimal balance)
    {
        if (_currentCustomerManager.Customer is null)
            throw new CurrentCustomerManagerNullException(nameof(CustomerBalanceViewService));

        if (_currentCustomerManager.Customer.State is CustomerAccountState.Close)
        {
            balance = 0;
            return new TransactionResult.Rejected();
        }

        balance = _currentCustomerManager.Customer.Balance;
        return new TransactionResult.Success();
    }
}