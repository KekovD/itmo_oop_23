using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

public interface IBuildChecker
{
    void CheckMotherboardFormFactor(in CaseBase pcCase, in MotherboardBase motherboard, IList<BuildStatus> result);

    void CheckSocket(in CentralProcessorBase processor, in MotherboardBase motherboard, IList<BuildStatus> result);
    void CheckProcessorBios(in CentralProcessorBase processor, in MotherboardBase motherboard, IList<BuildStatus> result);

    void CheckSocketCoolingSystem(in CoolingSystemBase coolingSystem, in MotherboardBase motherboard, IList<BuildStatus> result);

    void CheckHeightCoolingSystem(in CoolingSystemBase coolingSystem, in CaseBase pcCase, IList<BuildStatus> result);

    void CheckTdpCoolingSystem(in CoolingSystemBase coolingSystem, in CentralProcessorBase processor, IList<BuildStatus> result);

    void CheckDdrType(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result);

    void CheckXmp(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result);

    void CheckFrequencyOperationMemory(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result);

    void CheckDdrPortsNumber(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result);

    void CheckDimensionsGraphicsCard(in GraphicsCardBase graphicsCard, in CaseBase pcCase, IList<BuildStatus> result);

    void CheckPciENumberGraphicsCard(in GraphicsCardBase graphicsCard, ref MotherboardBase motherboard, IList<BuildStatus> result);

    void CheckPciEVersionGraphicsCard(in GraphicsCardBase graphicsCard, in MotherboardBase motherboard, IList<BuildStatus> result);

    void CheckBuiltInWiFiModule(in MotherboardBase motherboard, IList<BuildStatus> result);

    void CheckSataNumber(ref MotherboardBase motherboard, IList<BuildStatus> result);

    void CheckPortsSolidStateDrive(in SsdBase solidStateDrive, ref MotherboardBase motherboard, IList<BuildStatus> result);

    void CheckVideoCoreAvailability(in CentralProcessorBase processor, GraphicsCardBase? graphicsCard, IList<BuildStatus> result);

    void CheckPowerConsumption(
        in PowerSupplyBase powerSupply,
        in CentralProcessorBase processor,
        in GraphicsCardBase? graphicsCardBase,
        in SsdBase? ssdBase,
        in HddBase? hddBase,
        in RamBase ramBase,
        in WiFiModuleBase? wiFiModuleBase,
        IList<BuildStatus> result);

    IList<BuildStatus> ReportWriting(IList<BuildStatus> criticalErrors, IList<BuildStatus> warrantyCancellation);
}