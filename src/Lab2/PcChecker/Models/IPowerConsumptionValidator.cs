using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

public interface IPowerConsumptionValidator
{
    IPowerConsumptionValidator CheckPowerConsumption(
        in PowerSupplyBase powerSupply,
        in CentralProcessorBase processor,
        in GraphicsCardBase? graphicsCardBase,
        in SsdBase? ssdBase,
        in HddBase? hddBase,
        in RamBase ramBase,
        in WiFiModuleBase? wiFiModuleBase,
        IList<BuildStatus> result);
}