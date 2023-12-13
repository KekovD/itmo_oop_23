using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Admins;

namespace Lab5.Application.Admins;

internal class AdminLoginService : IAdminLoginService
{
    private readonly IAdminAccountsRepository _repository;
    private readonly CurrentAdminManager _currentAdminManager;
    private readonly IPasswordHasher _passwordHasher;

    public AdminLoginService(IAdminAccountsRepository repository, CurrentAdminManager currentAdminManager, IPasswordHasher passwordHasher)
    {
        _repository = repository;
        _currentAdminManager = currentAdminManager;
        _passwordHasher = passwordHasher;
    }

    public async Task<AdminLoginResult> Login(long accountId, string plainTextPassword)
    {
        AdminAccount? admin = await _repository.FindAccountByAccountId(accountId);

        if (admin is null)
            return new AdminLoginResult.NotFound();

        string? hashedPassword = await _repository.FindAdminPasswordByAccountId(accountId);

        if (hashedPassword is not null &&
            _passwordHasher.VerifyHashedPassword(hashedPassword, plainTextPassword) != new PasswordVerificationResult.Success())
        {
            return new AdminLoginResult.WrongPassword();
        }

        _currentAdminManager.Admin = admin;
        return new AdminLoginResult.Success();
    }
}