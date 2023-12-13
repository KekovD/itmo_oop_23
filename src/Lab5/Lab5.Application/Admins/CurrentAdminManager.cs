using Application.Models.Accounts;
using Lab5.Application.Contracts.Admins;

namespace Lab5.Application.Admins;

internal class CurrentAdminManager : ICurrentAdminService
{
    public AdminAccount? Admin { get; set; }
}