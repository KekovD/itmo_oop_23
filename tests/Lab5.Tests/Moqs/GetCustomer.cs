using Application.Abstractions.Repositories;
using Lab5.Presentation.Console.Scenarios.CustomerScenarios;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public class GetCustomer : ICustomerLoginSubScenario
{
    private readonly MoqCurrentCustomerService _service;
    private readonly ICustomerAccountsRepository _repository;

    public GetCustomer(MoqCurrentCustomerService service, ICustomerAccountsRepository repository)
    {
        _service = service;
        _repository = repository;
    }

    public string Name => "GetCustomer";

    public void Run()
    {
        if (_service.Customer is not null)
            _service.Customer = _repository.FindAccountByAccountId(_service.Customer.AccountId);
    }
}