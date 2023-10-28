using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

public interface IOperationMemoryValidator
{
    IOperationMemoryValidator CheckDdrType(RamBase operationMemory, MotherboardBase motherboard, IList<BuildStatus> result);

    IOperationMemoryValidator CheckXmp(RamBase operationMemory, MotherboardBase motherboard, IList<BuildStatus> result);

    IOperationMemoryValidator CheckFrequencyOperationMemory(RamBase operationMemory, MotherboardBase motherboard, IList<BuildStatus> result);

    IOperationMemoryValidator CheckDdrPortsNumber(RamBase operationMemory, MotherboardBase motherboard, IList<BuildStatus> result);
}