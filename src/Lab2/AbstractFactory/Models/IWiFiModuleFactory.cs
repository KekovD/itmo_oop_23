using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiBuiltInBluetooth.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IWiFiModuleFactory
{
    public IWiFiModuleFactory RepositoryInstances(IList<object> instances);
    public WiFiModuleBase Crate();

    public IWiFiModuleFactory CustomInstances(
        string name,
        string standardVersion,
        PciEVersionBase pciEVersion,
        IBuiltInBluetooth builtInBluetooth,
        int powerConsumption);
}