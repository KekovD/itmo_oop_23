using Application.Models.Operations;

namespace Lab5.Application.Contracts.Customers;

public interface ICustomerViewAllOperationsHistoryService
{
    IEnumerable<Operation> ViewAllOperationsHistory();
}