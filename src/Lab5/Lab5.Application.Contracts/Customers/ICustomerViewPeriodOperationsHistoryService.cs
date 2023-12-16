using Application.Models.Operations;

namespace Lab5.Application.Contracts.Customers;

public interface ICustomerViewPeriodOperationsHistoryService
{
    IEnumerable<Operation> ViewPeriodOperationsHistory(DateTime startDate, DateTime endDate);
}