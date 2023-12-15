using Application.Models.Accounts;
using Lab5.Application.Contracts.Customers;
using Lab5.Presentation.Console.Scenarios.CustomerScenarios;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public class MoqCustomerRegisterScenario : ICustomerLoginSubScenario
{
    private readonly ICustomerRegisterService _userService;
    private readonly ICurrentCustomerService _service;
    private readonly IMoqCurrentCustomerService _moqCurrentCustomer;

    public MoqCustomerRegisterScenario(ICustomerRegisterService userService, ICurrentCustomerService service, IMoqCurrentCustomerService moqCurrentCustomer)
    {
        _userService = userService;
        _service = service;
        _moqCurrentCustomer = moqCurrentCustomer;
    }

    public string Name => "Register";

    public void Run()
    {
        CustomerAccount? newAccount = _moqCurrentCustomer.Customer;

        if (newAccount is null)
            return;

        _userService.Register(newAccount, "0");
    }
}