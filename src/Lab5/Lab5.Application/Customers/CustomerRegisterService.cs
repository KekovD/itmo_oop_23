using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Application.Models.Users;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Customers;

namespace Lab5.Application.Customers;

internal class CustomerRegisterService : ICustomerRegisterService
{
    private readonly ICustomerAccountsRepository _repository;
    private readonly CurrentCustomerManager _currentCustomerManager;
    private readonly IPasswordHasher _passwordHasher;

    public CustomerRegisterService(
        ICustomerAccountsRepository repository,
        CurrentCustomerManager currentCustomerManager,
        IPasswordHasher passwordHasher)
    {
        _repository = repository;
        _currentCustomerManager = currentCustomerManager;
        _passwordHasher = passwordHasher;
    }

    public RegisterResult Register(User user, CustomerAccount newAccount, string plainTextPassword)
    {
        CustomerAccount? existingAccount = _repository.FindAccountByAccountId(newAccount.AccountId);

        if (existingAccount != null)
            return new RegisterResult.AccountAlreadyExists();

        string hashedPassword = _passwordHasher.HashPassword(plainTextPassword);

        _repository.CreateCustomer(user, newAccount, hashedPassword);

        _currentCustomerManager.Customer = newAccount;
        return new RegisterResult.Success();
    }
}