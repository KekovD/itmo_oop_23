using Application.Models.Operations;

namespace Application.Abstractions.Repositories;

public interface IAdminViewOperationsHistoryRepository
{
    IAsyncEnumerable<Operation> GetAllOperationsHistory();
    IAsyncEnumerable<Operation> GetAllOperationsHistoryByCustomerAccountId(long customerAccountId);
}