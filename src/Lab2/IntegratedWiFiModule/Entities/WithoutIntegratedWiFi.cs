using Itmo.ObjectOrientedProgramming.Lab2.IntegratedWiFiModule.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.IntegratedWiFiModule.Entities;

public class WithoutIntegratedWiFi : IIntegratedWiFi
{
    public IIntegratedWiFi Clone() => new WithoutIntegratedWiFi();
}