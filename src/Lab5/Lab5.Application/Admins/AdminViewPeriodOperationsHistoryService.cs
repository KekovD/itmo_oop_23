using Application.Abstractions.Repositories;
using Application.Models.Operations;
using Lab5.Application.Contracts.Admins;

namespace Lab5.Application.Admins;

public class AdminViewPeriodOperationsHistoryService : IAdminViewPeriodOperationsHistoryService
{
    private readonly IAdminViewOperationsHistoryRepository _repository;

    public AdminViewPeriodOperationsHistoryService(IAdminViewOperationsHistoryRepository repository)
    {
        _repository = repository;
    }

    public async IAsyncEnumerable<Operation> ViewPeriodOperationsHistory(DateTime startDate, DateTime endDate)
    {
        await foreach (Operation operation in _repository.FindPeriodOperationsHistory(startDate, endDate))
        {
            yield return operation;
        }
    }
}