using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public class CoolingSystemValidator : ICoolingSystemValidator
{
    public ICoolingSystemValidator CheckSocketCoolingSystem(CoolingSystemBase coolingSystem, MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (coolingSystem.SupportedSockets.Any(socket => socket.CompareSocket(motherboard.Socket)))
        {
            return this;
        }

        result.Add(BuildStatus.CoolingSystemDoesNotSupportDesiredSocket);

        return this;
    }

    public ICoolingSystemValidator CheckHeightCoolingSystem(CoolingSystemBase coolingSystem, CaseBase pcCase, IList<BuildStatus> result)
    {
        if (pcCase.MaximumWidth > coolingSystem.Dimensions[0])
            return this;

        result.Add(BuildStatus.CoolerIsTooHigh);

        return this;
    }

    public ICoolingSystemValidator CheckTdpCoolingSystem(CoolingSystemBase coolingSystem, CentralProcessorBase processor, IList<BuildStatus> result)
    {
        if (coolingSystem.ThermalDesignPower > processor.ThermalDesignPower)
            return this;

        result.Add(BuildStatus.WarrantyDisclaimerCoolerHasTooLowTdp);

        return this;
    }
}