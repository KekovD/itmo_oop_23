using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IHddFactory : IFactory
{
    public IPart CreateCustom(
        string name,
        int capacity,
        int spindleSpeed,
        int powerConsumption);
}