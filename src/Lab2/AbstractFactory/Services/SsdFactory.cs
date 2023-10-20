using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.SsdType.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class SsdFactory : ISsdFactory
{
    public IPart CreateByName(string name) =>
        new Ssd(new SsdRepository().GetByName(name));

    public IPart CreateCustom(
        string name,
        SsdTypeBase connectionOption,
        int capacity,
        int maximumSpeed,
        int powerConsumption)
    {
        return new Ssd(name, connectionOption, capacity, maximumSpeed, powerConsumption);
    }
}