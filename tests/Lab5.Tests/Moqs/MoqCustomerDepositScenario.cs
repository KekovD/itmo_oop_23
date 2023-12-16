using Lab5.Application.Contracts.Customers;
using Lab5.Presentation.Console.Scenarios.CustomerScenarios;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public class MoqCustomerDepositScenario : ICustomerLoginSubScenario
{
    private readonly ICustomerDepositService _service;
    private readonly OperationAmount _operationAmount;

    public MoqCustomerDepositScenario(ICustomerDepositService service, OperationAmount operationAmount)
    {
        _service = service;
        _operationAmount = operationAmount;
    }

    public string Name => "Deposit";

    public void Run()
    {
        _service.Replenishment(_operationAmount.Amount);
    }
}