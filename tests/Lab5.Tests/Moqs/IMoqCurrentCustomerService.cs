using Application.Models.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moqs;

public interface IMoqCurrentCustomerService
{
    CustomerAccount? Customer { get; }
}