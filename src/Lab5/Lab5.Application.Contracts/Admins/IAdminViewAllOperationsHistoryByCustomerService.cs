using Application.Models.Operations;

namespace Lab5.Application.Contracts.Admins;

public interface IAdminViewAllOperationsHistoryByCustomerService
{
    IEnumerable<Operation> ViewAllOperationsHistoryByCustomer(long customerAccountId);
}