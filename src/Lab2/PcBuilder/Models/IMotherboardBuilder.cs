using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcBuilder.Models;

public interface IMotherboardBuilder
{
    IСentralProcessorBuilder WithMotherboard(MotherboardBase motherboard);
}