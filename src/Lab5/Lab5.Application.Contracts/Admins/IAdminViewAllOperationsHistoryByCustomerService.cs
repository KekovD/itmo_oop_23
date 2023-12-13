using Application.Models.Operations;

namespace Lab5.Application.Contracts.Admins;

public interface IAdminViewAllOperationsHistoryByCustomerService
{
    IAsyncEnumerable<Operation> ViewAllOperationsHistoryByCustomer(long customerAccountId);
}