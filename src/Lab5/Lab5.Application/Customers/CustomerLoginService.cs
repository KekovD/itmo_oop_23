using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Workshop5.Application.Contracts;
using Workshop5.Application.Contracts.Customers;

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

    public async Task<LoginResult> Login(long accountId, string password)
    {
        CustomerAccount? customer = await _repository.FindAccountByAccountId(accountId);

        if (customer is null)
            return new LoginResult.NotFound();

        string? hashedPassword = await _repository.FindAccountPasswordByAccountId(accountId);

        if (hashedPassword is not null &&
            _passwordHasher.VerifyHashedPassword(hashedPassword, password) != new PasswordVerificationResult.Success())
        {
            return new LoginResult.Failure();
        }

        _currentCustomerManager.Customer = customer;
        return new LoginResult.Success();
    }
}