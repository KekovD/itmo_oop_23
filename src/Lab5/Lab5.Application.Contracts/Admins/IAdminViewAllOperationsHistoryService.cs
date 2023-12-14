using Application.Models.Operations;

namespace Lab5.Application.Contracts.Admins;

public interface IAdminViewAllOperationsHistoryService
{
    IEnumerable<Operation> ViewAllOperationsHistory();
}