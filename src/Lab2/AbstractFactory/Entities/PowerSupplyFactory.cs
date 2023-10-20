using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Entities;

public class PowerSupplyFactory : IPowerSupplyFactory
{
    public IPart CreateByName(string name) =>
        new PowerSupply(new PowerSupplyRepository().GetByName(name));

    public IPart CreateCustom(string name, int peakLoad)
    {
        return new PowerSupply(name, peakLoad);
    }
}