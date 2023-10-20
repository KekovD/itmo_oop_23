using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcBuilder.Models;

public interface ICoolingSystemBuilder
{
    IOperatingMemoryBuilder WithCoolingSystem(CoolingSystemBase coolingSystem);
}