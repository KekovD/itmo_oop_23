using Application.Abstractions.Repositories;
using Application.Models.Accounts;
using Lab5.Application.Contracts;
using Lab5.Application.Contracts.Admins;

namespace Lab5.Application.Admins;

internal class AddAdminsService : IAddAdminsService
{
    private readonly IAdminAccountsRepository _repository;
    private readonly IPasswordHasher _passwordHasher;

    public AddAdminsService(IAdminAccountsRepository repository, IPasswordHasher passwordHasher)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
    }

    public void AddAdmin(AdminAccount adminAccounts, string plainTextPassword)
    {
        string hashedPassword = _passwordHasher.HashPassword(plainTextPassword);

        _repository.AddAdmin(adminAccounts, hashedPassword);
    }
}