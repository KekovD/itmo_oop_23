using Lab5.Application.Contracts.Customers;

namespace Lab5.Application.Customers;

internal class CustomerLogoutService : ICustomerLogoutService
{
    private readonly CurrentCustomerManager _currentCustomerManager;

    public CustomerLogoutService(CurrentCustomerManager currentCustomerManager)
    {
        _currentCustomerManager = currentCustomerManager;
    }

    public void Logout() => _currentCustomerManager.Customer = null;
}