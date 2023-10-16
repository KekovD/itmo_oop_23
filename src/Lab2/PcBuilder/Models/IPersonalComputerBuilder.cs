using Itmo.ObjectOrientedProgramming.Lab2.PC.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcBuilder.Models;

public interface IPersonalComputerBuilder
{
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