using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiBuiltInBluetooth.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;

public abstract class WiFiModuleBase : IPowerConsumption, IPrototype<WiFiModuleBase>
{
    protected WiFiModuleBase(
        string name,
        string standardVersion,
        PciEVersionBase pciEVersion,
        IBuiltInBluetooth builtInBluetooth,
        int powerConsumption)
    {
        Name = name;
        StandardVersion = standardVersion;
        PciEVersion = pciEVersion;
        BuiltInBluetooth = builtInBluetooth;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public string StandardVersion { get; private set; }
    public PciEVersionBase PciEVersion { get; private set; }
    public IBuiltInBluetooth BuiltInBluetooth { get; private set; }
    public int PowerConsumption { get; }

    public abstract WiFiModuleBase Clone();
}