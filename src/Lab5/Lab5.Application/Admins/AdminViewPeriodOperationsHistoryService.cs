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

    public IEnumerable<Operation> ViewPeriodOperationsHistory(DateTime startDate, DateTime endDate) =>
        _repository.FindPeriodOperationsHistory(startDate, endDate);
}