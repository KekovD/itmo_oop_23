using Itmo.ObjectOrientedProgramming.Lab2.IntegratedWiFiModule.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.IntegratedWiFiModule.Entities;

public class IntegratedWiFi : IIntegratedWiFi
{
    public IIntegratedWiFi Clone() => new IntegratedWiFi();

    public bool HaveIntegratedWiFi() => true;
}