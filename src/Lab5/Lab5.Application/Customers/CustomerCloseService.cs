﻿using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Customers;
using Lab5.Application.Exceptions;

namespace Lab5.Application.Customers;

internal class CustomerCloseService : ICustomerCloseService
{
    private readonly ICustomerAccountsRepository _repository;
    private readonly CurrentCustomerManager _currentCustomerManager;
    private readonly IPasswordHasher _passwordHasher;

    public CustomerCloseService(ICustomerAccountsRepository repository, CurrentCustomerManager currentCustomerManager, IPasswordHasher passwordHasher)
    {
        _repository = repository;
        _currentCustomerManager = currentCustomerManager;
        _passwordHasher = passwordHasher;
    }

    public async Task<CloseResult> DeleteAccount(string plainTextPassword)
    {
        if (_currentCustomerManager.Customer is null)
            throw new CurrentCustomerManagerNullException(nameof(CustomerCloseService));

        if (_currentCustomerManager.Customer.State is CustomerAccountState.Close)
            return new CloseResult.WrongPassword();

        string? hashedPassword = await _repository.FindAccountPasswordByAccountId(_currentCustomerManager.Customer.AccountId);

        if (hashedPassword is not null &&
            _passwordHasher.VerifyHashedPassword(hashedPassword, plainTextPassword) != new PasswordVerificationResult.Success())
        {
            return new CloseResult.WrongPassword();
        }

        await _repository.ChangeAccountStateToClose(_currentCustomerManager.Customer, DateTime.Now);
        return new CloseResult.Success();
    }
}