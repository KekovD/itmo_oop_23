﻿using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiBuiltInBluetooth.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IWiFiModuleFactory : IFactory
{
    public IPart CreateCustom(
        string name,
        string standardVersion,
        PciEVersionBase pciEVersion,
        IBuiltInBluetooth builtInBluetooth,
        int powerConsumption);
}