using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcBuilder.Models;

public interface IСentralProcessorBuilder
{
    ICoolingSystemBuilder WithCentralProcessor(CentralProcessorBase centralProcessor);
}