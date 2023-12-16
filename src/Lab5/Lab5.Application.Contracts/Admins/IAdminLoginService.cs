namespace Lab5.Application.Contracts.Admins;

public interface IAdminLoginService
{
    AdminLoginResult Login(long accountId, string plainTextPassword);
}