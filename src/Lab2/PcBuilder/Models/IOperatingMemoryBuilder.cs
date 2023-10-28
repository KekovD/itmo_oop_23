using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcBuilder.Models;

public interface IOperatingMemoryBuilder
{
    IAdditionalComponentsAndMemoryBuilder WithOperatingMemory(RamBase operatingMemory);
}