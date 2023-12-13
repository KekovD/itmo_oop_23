using Application.Models.Operations;

namespace Application.Abstractions.Repositories;

public interface IAdminViewOperationsHistoryRepository
{
    IAsyncEnumerable<Operation> FindAllOperationsHistory();
    IAsyncEnumerable<Operation> FindAllOperationsHistoryByCustomerAccountId(long customerAccountId);
    IAsyncEnumerable<Operation> FindPeriodOperationsHistory(DateTime startDate, DateTime endDate);
    IAsyncEnumerable<Operation> FindPeriodOperationsHistoryByCustomerAccountId(long accountId, DateTime startDate, DateTime endDate);
}