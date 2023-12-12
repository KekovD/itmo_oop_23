using Application.Models.Operations;

namespace Application.Abstractions.Repositories;

public interface IOperationsHistoryRepository
{
    IAsyncEnumerable<Operation> FindOperationsHistoryByAccountId(long accountId);
    Task AddOperationToHistory(Operation operation);
}