using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public class OperationMemoryValidator : IOperationMemoryValidator
{
    public IOperationMemoryValidator CheckDdrType(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (operationMemory.DdrType.CompareDdrType(motherboard.DdrMotherboard))
            return this;

        result.Add(BuildStatus.UnsuitableDdrType);

        return this;
    }

    public IOperationMemoryValidator CheckXmp(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (operationMemory.ExtremeMemoryProfile.HaveXmp() && motherboard.ExtremeMemoryProfiles.HaveXmp())
            return this;

        if (operationMemory.ExtremeMemoryProfile.HaveXmp() == false && motherboard.ExtremeMemoryProfiles.HaveXmp() == false)
            return this;

        result.Add(BuildStatus.XmpInconsistency);

        return this;
    }

    public IOperationMemoryValidator CheckFrequencyOperationMemory(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (operationMemory.JedecProfile.Frequency >= motherboard.MemoryFrequencies)
            return this;

        result.Add(BuildStatus.RamFrequencyIsTooLow);

        return this;
    }

    public IOperationMemoryValidator CheckDdrPortsNumber(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (operationMemory.CardsNumber <= motherboard.RamTablesNumber)
            return this;

        result.Add(BuildStatus.NotEnoughDdrPortsOnMotherboard);

        return this;
    }
}