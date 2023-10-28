using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public class PowerConsumptionValidator : IPowerConsumptionValidator
{
    public IPowerConsumptionValidator CheckPowerConsumption(
        in PowerSupplyBase powerSupply,
        in CentralProcessorBase processor,
        in GraphicsCardBase? graphicsCardBase,
        in SsdBase? ssdBase,
        in HddBase? hddBase,
        in RamBase ramBase,
        in WiFiModuleBase? wiFiModuleBase,
        IList<BuildStatus> result)
    {
        int powerConsumption = processor.PowerConsumption + ramBase.PowerConsumption;

        if (graphicsCardBase is not null)
            powerConsumption += graphicsCardBase.PowerConsumption;

        if (ssdBase is not null)
            powerConsumption += ssdBase.PowerConsumption;

        if (hddBase is not null)
            powerConsumption += hddBase.PowerConsumption;

        if (wiFiModuleBase is not null)
            powerConsumption += wiFiModuleBase.PowerConsumption;

        if (powerConsumption <= powerSupply.PeakLoad)
            return this;

        result.Add(BuildStatus.InsufficientPowerSupplyCapacity);

        return this;
    }
}