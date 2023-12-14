using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Application.Models.Operations;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Customers;
using Lab5.Application.Exceptions;

namespace Lab5.Application.Customers;

internal class CustomerDepositService : ICustomerDepositService
{
    private readonly ICustomerAccountsRepository _customerRepository;
    private readonly CurrentCustomerManager _currentCustomerManager;
    private readonly IOperationsHistoryRepository _operationsHistoryRepository;

    public CustomerDepositService(
        ICustomerAccountsRepository customerRepository,
        CurrentCustomerManager currentCustomerManager,
        IOperationsHistoryRepository operationsHistoryRepository)
    {
        _customerRepository = customerRepository;
        _currentCustomerManager = currentCustomerManager;
        _operationsHistoryRepository = operationsHistoryRepository;
    }

    public TransactionResult Replenishment(decimal replenishmentAmount)
    {
        if (_currentCustomerManager.Customer is null)
            throw new CurrentCustomerManagerNullException(nameof(CustomerDepositService));

        const int nullId = 0;

        var operation = new Operation(
            _currentCustomerManager.Customer.AccountId,
            nullId,
            replenishmentAmount,
            OperationType.Deposit,
            OperationState.Failed,
            DateTime.Now);

        if (_currentCustomerManager.Customer.State is CustomerAccountState.Close)
        {
            _operationsHistoryRepository.AddOperationToHistory(operation);
            return new TransactionResult.Rejected();
        }

        decimal newBalance = _currentCustomerManager.Customer.Balance + replenishmentAmount;
        _customerRepository.ChangeBalance(_currentCustomerManager.Customer, newBalance);
        _operationsHistoryRepository.AddOperationToHistory(operation with { State = OperationState.Successful });

        return new TransactionResult.Success();
    }
}