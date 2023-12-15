using Lab5.Application.Contracts.Admins;

namespace Lab5.Application.Admins;

internal class AdminLogoutService : IAdminLogoutService
{
    private readonly CurrentAdminManager _currentAdminManager;

    public AdminLogoutService(CurrentAdminManager currentAdminManager)
    {
        _currentAdminManager = currentAdminManager;
    }

    public void Logout() => _currentAdminManager.Admin = null;
}