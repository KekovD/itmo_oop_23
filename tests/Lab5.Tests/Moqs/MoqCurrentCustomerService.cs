using Application.Models.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public class MoqCurrentCustomerService : IMoqCurrentCustomerService
{
    public CustomerAccount? Customer { get; set; }
}