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

    public IEnumerable<Operation> ViewAllOperationsHistoryByCustomer(long customerAccountId) =>
        _repository.FindAllOperationsHistoryByCustomerAccountId(customerAccountId);
}