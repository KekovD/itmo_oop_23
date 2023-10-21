using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public class BuildChecker : IBuildChecker
{
    public void CheckMotherboardFormFactor(in CaseBase pcCase, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        foreach (FormFactorMotherboardBase formFactor in pcCase.MotherboardFormFactors)
        {
            if (motherboard.FormFactor.CompareFormFactor(formFactor))
                return;
        }

        result.Add(BuildStatus.UnsuitableMotherboardFormFactor);
    }

    public void CheckSocket(in CentralProcessorBase processor, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (processor.Socket.CompareSocket(motherboard.Socket))
            return;

        result.Add(BuildStatus.UnsuitableSocketType);
    }

    public void CheckProcessorBios(in CentralProcessorBase processor, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (processor.Bios.CompareBios(motherboard.Bios))
            return;

        result.Add(BuildStatus.UnsuitableMotherboardBiosVersion);
    }

    public void CheckSocketCoolingSystem(in CoolingSystemBase coolingSystem, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        foreach (SocketBase socket in coolingSystem.SupportedSockets)
        {
            if (socket.CompareSocket(motherboard.Socket))
                return;
        }

        result.Add(BuildStatus.CoolingSystemDoesNotSupportDesiredSocket);
    }

    public void CheckHeightCoolingSystem(in CoolingSystemBase coolingSystem, in CaseBase pcCase, IList<BuildStatus> result)
    {
        if (pcCase.MaximumWidth < coolingSystem.Dimensions[0])
            return;

        result.Add(BuildStatus.CoolerIsTooHigh);
    }

    public void CheckTdpCoolingSystem(in CoolingSystemBase coolingSystem, in CentralProcessorBase processor, IList<BuildStatus> result)
    {
        if (coolingSystem.ThermalDesignPower > processor.ThermalDesignPower)
            return;

        result.Add(BuildStatus.WarrantyDisclaimerCoolerHasTooLowTdp);
    }

    public void CheckDdrType(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (operationMemory.DdrType.CompareDdrType(motherboard.DdrMotherboard))
            return;

        result.Add(BuildStatus.UnsuitableDdrType);
    }

    public void CheckXmp(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (operationMemory.ExtremeMemoryProfile.HaveXmp() && motherboard.ExtremeMemoryProfiles.HaveXmp())
            return;

        if (operationMemory.ExtremeMemoryProfile.HaveXmp() == false && motherboard.ExtremeMemoryProfiles.HaveXmp() == false)
            return;

        result.Add(BuildStatus.XmpInconsistency);
    }

    public void CheckFrequencyOperationMemory(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (operationMemory.JedecProfile.Frequency >= motherboard.MemoryFrequencies)
            return;

        result.Add(BuildStatus.RamFrequencyIsTooLow);
    }

    public void CheckDdrPortsNumber(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (operationMemory.CardsNumber <= motherboard.RamTablesNumber)
            return;

        result.Add(BuildStatus.NotEnoughDdrPortsOnMotherboard);
    }

    public void CheckDimensionsGraphicsCard(in GraphicsCardBase graphicsCard, in CaseBase pcCase, IList<BuildStatus> result)
    {
        if (graphicsCard.Height <= pcCase.MaximumWidth && graphicsCard.Width <= pcCase.MaximumLength)
            return;

        result.Add(BuildStatus.DimensionsOfGraphicsCardTooLarge);
    }

    public void CheckPciENumberGraphicsCard(in GraphicsCardBase graphicsCard, ref MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (motherboard.PciENumber > 0)
        {
            const int graphicsCardInstallation = 1;
            motherboard = motherboard.CloneWithNewPciENumber(motherboard.PciENumber - graphicsCardInstallation);
            return;
        }

        result.Add(BuildStatus.InsufficientNumberOfPciEPorts);
    }

    public void CheckPciEVersionGraphicsCard(in GraphicsCardBase graphicsCard, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (graphicsCard.PciEVersion.Version >= motherboard.PciEVersion.Version)
            return;

        result.Add(BuildStatus.GraphicsCardHasTooOldVersionOfPciE);
    }

    public void CheckBuiltInWiFiModule(in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (!motherboard.IntegratedWiFi.HaveIntegratedWiFi())
            return;

        result.Add(BuildStatus.MotherboardAlreadyHasBuiltInWiFiModule);
    }

    public void CheckSataNumber(ref MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (motherboard.SataNumber > 0)
        {
            const int installation = 1;
            motherboard = motherboard.CloneWithNewSataNumber(motherboard.SataNumber - installation);
            return;
        }

        result.Add(BuildStatus.InsufficientNumberOfSataPorts);
    }

    public void CheckPortsSolidStateDrive(in SsdBase solidStateDrive, ref MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (solidStateDrive.ConnectionOption.InstallingSsd(ref motherboard))
            return;

        result.Add(BuildStatus.InsufficientNumberOfPortsForSsd);
    }

    public void CheckVideoCoreAvailability(in CentralProcessorBase processor, GraphicsCardBase? graphicsCard, IList<BuildStatus> result)
    {
        if (processor.IntegratedVideoCore.HaveIntegratedVideoCore() || graphicsCard is not null)
            return;

        result.Add(BuildStatus.VideoCoreIsRequired);
    }

    public void CheckPowerConsumption(
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
            return;

        result.Add(BuildStatus.InsufficientPowerSupplyCapacity);
    }

    public IList<BuildStatus> ReportWriting(IList<BuildStatus> criticalErrors, IList<BuildStatus> warrantyCancellation)
    {
        var message = new List<BuildStatus>();

        if (criticalErrors.Count == 0)
        {
            message.Add(BuildStatus.Successfully);

            if (warrantyCancellation.Count != 0)
            {
                message.AddRange(warrantyCancellation);
            }

            return message;
        }

        message.AddRange(criticalErrors);

        return message;
    }
}