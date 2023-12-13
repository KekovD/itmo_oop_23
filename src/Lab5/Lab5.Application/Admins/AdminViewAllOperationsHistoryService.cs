using Application.Abstractions.Repositories;
using Application.Models.Operations;
using Lab5.Application.Contracts.Admins;

namespace Lab5.Application.Admins;

internal class AdminViewAllOperationsHistoryService : IAdminViewAllOperationsHistoryService
{
    private readonly IAdminViewOperationsHistoryRepository _repository;

    public AdminViewAllOperationsHistoryService(IAdminViewOperationsHistoryRepository repository)
    {
        _repository = repository;
    }

    public async IAsyncEnumerable<Operation> ViewAllOperationsHistory()
    {
        await foreach (Operation operation in _repository.FindAllOperationsHistory())
        {
            yield return operation;
        }
    }
}