using Application.Models.Operations;

namespace Lab5.Application.Contracts.Customers;

public interface ICustomerViewPeriodOperationsHistoryService
{
    IAsyncEnumerable<Operation> ViewPeriodOperationsHistory(DateTime startDate, DateTime endDate);
}