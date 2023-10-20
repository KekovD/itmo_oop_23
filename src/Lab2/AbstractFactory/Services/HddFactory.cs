using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class HddFactory : IHddFactory
{
    public IPart CreateByName(string name) =>
        new Hdd(new HddRepository().GetByName(name));

    public IPart CreateCustom(
        string name,
        int capacity,
        int spindleSpeed,
        int powerConsumption)
    {
        return new Hdd(name, capacity, spindleSpeed, powerConsumption);
    }
}