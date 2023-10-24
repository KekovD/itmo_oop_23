using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public class WiFiModuleValidator : IWiFiModuleValidator
{
    public IWiFiModuleValidator CheckBuiltInWiFiModule(in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (!motherboard.IntegratedWiFi.HaveIntegratedWiFi())
            return this;

        result.Add(BuildStatus.MotherboardAlreadyHasBuiltInWiFiModule);

        return this;
    }
}