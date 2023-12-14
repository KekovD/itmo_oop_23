using Application.Models.Accounts;
using Application.Models.Users;

namespace Lab5.Application.Contracts.Admins;

public interface IAddAdminsService
{
    void AddAdmin(User newUser, AdminAccount adminAccount, string hashedPassword);
}