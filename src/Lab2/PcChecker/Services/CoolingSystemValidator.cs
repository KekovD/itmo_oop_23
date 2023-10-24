using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public class CoolingSystemValidator : ICoolingSystemValidator
{
    public ICoolingSystemValidator CheckSocketCoolingSystem(in CoolingSystemBase coolingSystem, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        foreach (SocketBase socket in coolingSystem.SupportedSockets)
        {
            if (socket.CompareSocket(motherboard.Socket))
                return this;
        }

        result.Add(BuildStatus.CoolingSystemDoesNotSupportDesiredSocket);

        return this;
    }

    public ICoolingSystemValidator CheckHeightCoolingSystem(in CoolingSystemBase coolingSystem, in CaseBase pcCase, IList<BuildStatus> result)
    {
        if (pcCase.MaximumWidth > coolingSystem.Dimensions[0])
            return this;

        result.Add(BuildStatus.CoolerIsTooHigh);

        return this;
    }

    public ICoolingSystemValidator CheckTdpCoolingSystem(in CoolingSystemBase coolingSystem, in CentralProcessorBase processor, IList<BuildStatus> result)
    {
        if (coolingSystem.ThermalDesignPower > processor.ThermalDesignPower)
            return this;

        result.Add(BuildStatus.WarrantyDisclaimerCoolerHasTooLowTdp);

        return this;
    }
}