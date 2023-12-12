using Application.Abstractions.Repositories;
using Application.Models.Operations;
using Lab5.Application.Contracts.Customers;
using Lab5.Application.Exceptions;

namespace Lab5.Application.Customers;

internal class CustomerViewAllOperationsHistoryService : ICustomerViewAllOperationsHistoryService
{
    private readonly IOperationsHistoryRepository _repository;
    private readonly CurrentCustomerManager _currentCustomerManager;

    public CustomerViewAllOperationsHistoryService(IOperationsHistoryRepository repository, CurrentCustomerManager currentCustomerManager)
    {
        _repository = repository;
        _currentCustomerManager = currentCustomerManager;
    }

    public async IAsyncEnumerable<Operation> ViewAllOperationsHistory()
    {
        if (_currentCustomerManager.Customer is null)
            throw new CurrentCustomerManagerNullException(nameof(CustomerViewAllOperationsHistoryService));

        await foreach (Operation operation in _repository.FindOperationsHistoryByAccountId(_currentCustomerManager.Customer.AccountId))
        {
            yield return operation;
        }
    }
}