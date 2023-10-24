namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IHddFactory : IFactory
{
    public IFactory CustomInstances(
        string name,
        int capacity,
        int spindleSpeed,
        int powerConsumption);
}