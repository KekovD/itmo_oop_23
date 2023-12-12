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

    public CustomerDepositService(ICustomerAccountsRepository customerRepository, CurrentCustomerManager currentCustomerManager, IOperationsHistoryRepository operationsHistoryRepository)
    {
        _customerRepository = customerRepository;
        _currentCustomerManager = currentCustomerManager;
        _operationsHistoryRepository = operationsHistoryRepository;
    }

    public async Task<TransactionResult> Replenishment(decimal replenishmentAmount)
    {
        if (_currentCustomerManager.Customer is null)
            throw new CurrentCustomerManagerNullException(nameof(CustomerDepositService));

        const int nullId = 0;

        if (_currentCustomerManager.Customer.State is CustomerAccountState.Close)
        {
            var operation = new Operation(
                _currentCustomerManager.Customer.AccountId,
                nullId,
                replenishmentAmount,
                OperationType.Deposit,
                OperationState.Failed,
                DateTime.Now);

            await _operationsHistoryRepository.AddOperationToHistory(operation);

            return new TransactionResult.Rejected();
        }

        await _customerRepository.ChangeBalance(_currentCustomerManager.Customer, replenishmentAmount);

        var successfulOperation = new Operation(
            _currentCustomerManager.Customer.AccountId,
            nullId,
            replenishmentAmount,
            OperationType.Deposit,
            OperationState.Successful,
            DateTime.Now);

        await _operationsHistoryRepository.AddOperationToHistory(successfulOperation);

        return new TransactionResult.Success();
    }
}