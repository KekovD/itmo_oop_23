using Application.Models.Accounts;

namespace Lab5.Application.Contracts.Admins;

public interface IAddAdminsService
{
    void AddAdmin(AdminAccount adminAccount, string hashedPassword);
}