using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Application.Models.Operations;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Customers;
using Lab5.Application.Exceptions;

namespace Lab5.Application.Customers;

internal class CustomerWithdrawalService : ICustomerWithdrawalService
{
    private readonly ICustomerAccountsRepository _customerRepository;
    private readonly CurrentCustomerManager _currentCustomerManager;
    private readonly IOperationsHistoryRepository _operationsHistoryRepository;

    public CustomerWithdrawalService(
        ICustomerAccountsRepository customerRepository,
        CurrentCustomerManager currentCustomerManager,
        IOperationsHistoryRepository operationsHistoryRepository)
    {
        _customerRepository = customerRepository;
        _currentCustomerManager = currentCustomerManager;
        _operationsHistoryRepository = operationsHistoryRepository;
    }

    public TransactionResult Withdrawal(decimal withdrawalAmount)
    {
        if (_currentCustomerManager.Customer is null)
            throw new CurrentCustomerManagerNullException(nameof(CustomerWithdrawalService));

        const int nullId = 0;

        var operation = new Operation(
            _currentCustomerManager.Customer.AccountId,
            nullId,
            withdrawalAmount,
            OperationType.Withdrawal,
            OperationState.Failed,
            DateTime.Now);

        if (_currentCustomerManager.Customer.State is CustomerAccountState.Close
            || _currentCustomerManager.Customer.Balance < withdrawalAmount)
        {
            _operationsHistoryRepository.AddOperationToHistory(operation);
            return new TransactionResult.Rejected();
        }

        decimal newBalance = _currentCustomerManager.Customer.Balance - withdrawalAmount;
        _customerRepository.ChangeBalance(_currentCustomerManager.Customer, newBalance);
        _operationsHistoryRepository.AddOperationToHistory(operation with { State = OperationState.Successful });

        return new TransactionResult.Success();
    }
}