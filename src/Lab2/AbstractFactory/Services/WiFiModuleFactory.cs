using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiBuiltInBluetooth.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class WiFiModuleFactory : IWiFiModuleFactory
{
    private string? _name;
    private string? _standardVersion;
    private PciEVersionBase? _pciEVersion;
    private IBuiltInBluetooth? _builtInBluetooth;
    private int _powerConsumption;

    public IWiFiModuleFactory RepositoryInstances(IList<object> instances)
    {
        _name = (string)instances[0];
        _standardVersion = (string)instances[1];
        _pciEVersion = (PciEVersionBase)instances[2];
        _builtInBluetooth = (IBuiltInBluetooth)instances[3];
        _powerConsumption = (int)instances[4];

        return this;
    }

    public IWiFiModuleFactory CustomInstances(
        string name,
        string standardVersion,
        PciEVersionBase pciEVersion,
        IBuiltInBluetooth builtInBluetooth,
        int powerConsumption)
    {
        _name = name;
        _standardVersion = standardVersion;
        _pciEVersion = pciEVersion;
        _builtInBluetooth = builtInBluetooth;
        _powerConsumption = powerConsumption;

        return this;
    }

    public WiFiModuleBase Crate()
    {
        return new WiFiModule(
            _name ?? throw new CrateNullException(nameof(WiFiModuleFactory)),
            _standardVersion ?? throw new CrateNullException(nameof(WiFiModuleFactory)),
            _pciEVersion ?? throw new CrateNullException(nameof(WiFiModuleFactory)),
            _builtInBluetooth ?? throw new CrateNullException(nameof(WiFiModuleFactory)),
            _powerConsumption);
    }
}