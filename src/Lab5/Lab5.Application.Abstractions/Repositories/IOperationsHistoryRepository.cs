using Application.Models.Operations;

namespace Application.Abstractions.Repositories;

public interface IOperationsHistoryRepository
{
    IAsyncEnumerable<Operation> FindOperationsHistoryByAccountId(long accountId);

    IAsyncEnumerable<Operation> FindOperationsHistoryByAccountIdAndPeriod(long accountId, DateTime startDate, DateTime endDate);
    Task AddOperationToHistory(Operation operation);
}