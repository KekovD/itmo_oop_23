using Application.Models.Operations;

namespace Lab5.Application.Contracts.Admins;

public interface IAdminViewPeriodOperationsHistoryService
{
    IAsyncEnumerable<Operation> ViewPeriodOperationsHistory(DateTime startDate, DateTime endDate);
}