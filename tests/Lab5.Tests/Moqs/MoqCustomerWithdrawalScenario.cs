using Lab5.Application.Contracts.Customers;
using Lab5.Presentation.Console.Scenarios.CustomerScenarios;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public class MoqCustomerWithdrawalScenario : ICustomerLoginSubScenario
{
    private readonly ICustomerWithdrawalService _service;
    private readonly OperationAmount _operationAmount;

    public MoqCustomerWithdrawalScenario(ICustomerWithdrawalService service, OperationAmount operationAmount)
    {
        _service = service;
        _operationAmount = operationAmount;
    }

    public string Name => "Withdrawal";

    public void Run()
    {
        _service.Withdrawal(_operationAmount.Amount);
    }
}