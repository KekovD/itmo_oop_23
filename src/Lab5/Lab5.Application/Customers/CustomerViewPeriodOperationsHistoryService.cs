﻿using Application.Abstractions.Repositories;
using Application.Models.Operations;
using Lab5.Application.Contracts.Customers;
using Lab5.Application.Exceptions;

namespace Lab5.Application.Customers;

internal class CustomerViewPeriodOperationsHistoryService : ICustomerViewPeriodOperationsHistoryService
{
    private readonly IOperationsHistoryRepository _repository;
    private readonly CurrentCustomerManager _currentCustomerManager;

    public CustomerViewPeriodOperationsHistoryService(
        IOperationsHistoryRepository repository, CurrentCustomerManager currentCustomerManager)
    {
        _repository = repository;
        _currentCustomerManager = currentCustomerManager;
    }

    public IEnumerable<Operation> ViewPeriodOperationsHistory(DateTime startDate, DateTime endDate)
    {
        if (_currentCustomerManager.Customer is null)
            throw new CurrentCustomerManagerNullException(nameof(CustomerViewPeriodOperationsHistoryService));

        return _repository.FindPeriodOperationsHistoryByAccountId(
            _currentCustomerManager.Customer.AccountId, startDate, endDate);
    }
}