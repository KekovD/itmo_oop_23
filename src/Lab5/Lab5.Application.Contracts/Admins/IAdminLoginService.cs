namespace Lab5.Application.Contracts.Admins;

public interface IAdminLoginService
{
    Task<AdminLoginResult> Login(long accountId, string plainTextPassword);
}