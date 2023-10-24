using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

public interface IOperationMemoryValidator
{
    IOperationMemoryValidator CheckDdrType(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result);

    IOperationMemoryValidator CheckXmp(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result);

    IOperationMemoryValidator CheckFrequencyOperationMemory(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result);

    IOperationMemoryValidator CheckDdrPortsNumber(in RamBase operationMemory, in MotherboardBase motherboard, IList<BuildStatus> result);
}