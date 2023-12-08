using Application.Models.Operations;

namespace Application.Abstractions.Repositories;

public interface IOperationsHistoryRepository
{
    IEnumerable<Operation> FindOperationsHistoryById(long accountId);
}