using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiBuiltInBluetooth.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Entities;

public class WiFiModuleFactory : IWiFiModuleFactory
{
    public IPart CreateByName(string name) =>
        new WiFiModule(new WiFiModuleRepository().GetByName(name));

    public IPart CreateCustom(
        string name,
        string standardVersion,
        PciEVersionBase pciEVersion,
        IBuiltInBluetooth builtInBluetooth,
        int powerConsumption)
    {
        return new WiFiModule(name, standardVersion, pciEVersion, builtInBluetooth, powerConsumption);
    }
}