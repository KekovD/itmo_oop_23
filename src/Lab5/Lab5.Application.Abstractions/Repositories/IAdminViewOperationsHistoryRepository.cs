using Application.Models.Operations;

namespace Application.Abstractions.Repositories;

public interface IAdminViewOperationsHistoryRepository
{
    IEnumerable<Operation> FindAllOperationsHistory();
    IEnumerable<Operation> FindAllOperationsHistoryByCustomerAccountId(long customerAccountId);
    IEnumerable<Operation> FindPeriodOperationsHistory(DateTime startDate, DateTime endDate);
    IEnumerable<Operation> FindPeriodOperationsHistoryByCustomerAccountId(long accountId, DateTime startDate, DateTime endDate);
}