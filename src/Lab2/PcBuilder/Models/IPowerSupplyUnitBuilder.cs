using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcBuilder.Models;

public interface IPowerSupplyUnitBuilder
{
    IPersonalComputerBuilder WithPowerSupplyUnit(PowerSupplyBase powerSupply);
}