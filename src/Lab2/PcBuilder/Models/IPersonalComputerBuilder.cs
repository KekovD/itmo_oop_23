using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcBuilder.Models;

public interface IPersonalComputerBuilder
{
    //// Todo refactor return types
    IPersonalComputerBuilder AddCase();

    IPersonalComputerBuilder AddPowerSupplyUnit();

    IPersonalComputerBuilder AddMotherboard();

    IPersonalComputerBuilder СentralProcessor();

    IPersonalComputerBuilder AddCoolingSystem();

    IPersonalComputerBuilder AddOperatingMemory();

    IPersonalComputerBuilder AddGraphicsCard();

    IPersonalComputerBuilder AddHardDriver();

    IPersonalComputerBuilder AddSolidStateDrive();

    IPersonalComputer Build();
}