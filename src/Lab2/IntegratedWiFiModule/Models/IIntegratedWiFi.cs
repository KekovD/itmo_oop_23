using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.IntegratedWiFiModule.Models;

public interface IIntegratedWiFi : IPrototype<IIntegratedWiFi>
{
    bool HaveIntegratedWiFi();
}