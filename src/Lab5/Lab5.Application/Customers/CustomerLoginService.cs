using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Customers;

namespace Lab5.Application.Customers;

internal class CustomerLoginService : ICustomerLoginService
{
    private readonly ICustomerAccountsRepository _repository;
    private readonly CurrentCustomerManager _currentCustomerManager;
    private readonly IPasswordHasher _passwordHasher;

    public CustomerLoginService(
        ICustomerAccountsRepository repository,
        CurrentCustomerManager currentCustomerManager,
        IPasswordHasher passwordHasher)
    {
        _repository = repository;
        _currentCustomerManager = currentCustomerManager;
        _passwordHasher = passwordHasher;
    }

    public CustomerLoginResult Login(long accountId, string plainTextPassword)
    {
        CustomerAccount? customer = _repository.FindAccountByAccountId(accountId);

        if (customer is null)
            return new CustomerLoginResult.NotFound();

        if (customer.State.Equals(CustomerAccountState.Close))
            return new CustomerLoginResult.AccountClosed();

        string? hashedPassword = _repository.FindAccountPasswordByAccountId(accountId);

        if (!string.IsNullOrEmpty(hashedPassword) &&
            _passwordHasher.VerifyHashedPassword(hashedPassword, plainTextPassword) is not
            PasswordVerificationResult.Success)
        {
            return new CustomerLoginResult.WrongPassword();
        }

        _currentCustomerManager.Customer = customer;
        return new CustomerLoginResult.Success();
    }
}