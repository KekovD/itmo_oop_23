using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiBuiltInBluetooth.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Entities;

public class WiFiModule : WiFiModuleBase
{
    public WiFiModule(
        string name,
        string standardVersion,
        PciEVersionBase pciEVersion,
        IBuiltInBluetooth builtInBluetooth,
        int powerConsumption)
        : base(name, standardVersion, pciEVersion, builtInBluetooth, powerConsumption)
    {
    }

    public override WiFiModuleBase Clone()
    {
        return new WiFiModule(
            (string)Name.Clone(),
            (string)StandardVersion.Clone(),
            PciEVersion.Clone(),
            BuiltInBluetooth.Clone(),
            PowerConsumption);
    }
}