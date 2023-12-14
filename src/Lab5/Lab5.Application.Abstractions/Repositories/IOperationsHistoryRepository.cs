using Application.Models.Operations;

namespace Application.Abstractions.Repositories;

public interface IOperationsHistoryRepository
{
    IEnumerable<Operation> FindOperationsHistoryByAccountId(long accountId);
    IEnumerable<Operation> FindPeriodOperationsHistoryByAccountId(long accountId, DateTime startDate, DateTime endDate);
    void AddOperationToHistory(Operation operation);
}