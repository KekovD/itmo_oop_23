using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Customers;
using Lab5.Application.Exceptions;

namespace Lab5.Application.Customers;

internal class CustomerBalanceViewService : ICustomerBalanceViewService
{
    private readonly CurrentCustomerManager _currentCustomerManager;
    private readonly ICustomerAccountsRepository _accountsRepository;

    public CustomerBalanceViewService(CurrentCustomerManager currentCustomerManager, ICustomerAccountsRepository accountsRepository)
    {
        _currentCustomerManager = currentCustomerManager;
        _accountsRepository = accountsRepository;
    }

    public TransactionResult ViewBalance(out decimal balance)
    {
        if (_currentCustomerManager.Customer is null)
            throw new CurrentCustomerManagerNullException(nameof(CustomerBalanceViewService));

        decimal? repositoryBalance = _accountsRepository.FindBalanceByAccountId(_currentCustomerManager.Customer.AccountId);

        if (repositoryBalance is null || _currentCustomerManager.Customer.State is AccountState.Close)
        {
            balance = 0;
            return new TransactionResult.Rejected();
        }

        balance = repositoryBalance.Value;
        return new TransactionResult.Success();
    }
}