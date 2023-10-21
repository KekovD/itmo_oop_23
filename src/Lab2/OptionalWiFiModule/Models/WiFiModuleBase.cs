using System.Collections.Generic;
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

    protected WiFiModuleBase(IList<object> characteristics)
    {
        Name = (string)characteristics[0];
        StandardVersion = (string)characteristics[1];
        PciEVersion = (PciEVersionBase)characteristics[2];
        BuiltInBluetooth = (IBuiltInBluetooth)characteristics[3];
        PowerConsumption = (int)characteristics[4];
    }

    public string Name { get; private set; }
    public string StandardVersion { get; private set; }
    public PciEVersionBase PciEVersion { get; private set; }
    public IBuiltInBluetooth BuiltInBluetooth { get; private set; }
    public int PowerConsumption { get; private set; }

    public abstract WiFiModuleBase Clone();

    public WiFiModuleBase CloneWithNewName(string name)
    {
        WiFiModuleBase clone = Clone();
        clone.Name = name;

        return clone;
    }

    public WiFiModuleBase CloneWithNewStandardVersion(string standardVersion)
    {
        WiFiModuleBase clone = Clone();
        clone.StandardVersion = standardVersion;

        return clone;
    }

    public WiFiModuleBase CloneWithNewPciEVersion(PciEVersionBase pciEVersion)
    {
        WiFiModuleBase clone = Clone();
        clone.PciEVersion = pciEVersion;

        return clone;
    }

    public WiFiModuleBase CloneWithNewBuiltInBluetooth(IBuiltInBluetooth builtInBluetooth)
    {
        WiFiModuleBase clone = Clone();
        clone.BuiltInBluetooth = builtInBluetooth;

        return clone;
    }

    public WiFiModuleBase CloneWithNewPowerConsumption(int powerConsumption)
    {
        WiFiModuleBase clone = Clone();
        clone.PowerConsumption = powerConsumption;

        return clone;
    }
}