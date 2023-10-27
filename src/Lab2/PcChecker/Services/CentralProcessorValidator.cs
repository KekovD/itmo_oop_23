using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public class CentralProcessorValidator : ICentralProcessorValidator
{
    public ICentralProcessorValidator CheckSocket(CentralProcessorBase processor, MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (processor.Socket.CompareSocket(motherboard.Socket))
            return this;

        result.Add(BuildStatus.UnsuitableSocketType);

        return this;
    }

    public ICentralProcessorValidator CheckProcessorBios(CentralProcessorBase processor, MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (processor.Bios.CompareBios(motherboard.Bios))
            return this;

        result.Add(BuildStatus.UnsuitableMotherboardBiosVersion);

        return this;
    }
}