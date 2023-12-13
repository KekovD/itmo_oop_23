using Application.Models.Accounts;

namespace Lab5.Application.Contracts.Admins;

public interface ICurrentAdminService
{
    AdminAccount? Admin { get; }
}