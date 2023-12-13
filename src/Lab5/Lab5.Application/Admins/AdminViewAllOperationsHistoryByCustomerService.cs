using Application.Abstractions.Repositories;
using Application.Models.Operations;
using Lab5.Application.Contracts.Admins;

namespace Lab5.Application.Admins;

public class AdminViewAllOperationsHistoryByCustomerService : IAdminViewAllOperationsHistoryByCustomerService
{
    private readonly IAdminViewOperationsHistoryRepository _repository;

    public AdminViewAllOperationsHistoryByCustomerService(IAdminViewOperationsHistoryRepository repository)
    {
        _repository = repository;
    }

    public async IAsyncEnumerable<Operation> ViewAllOperationsHistoryByCustomer(long customerAccountId)
    {
        await foreach (Operation operation in _repository.FindAllOperationsHistoryByCustomerAccountId(customerAccountId))
        {
            yield return operation;
        }
    }
}