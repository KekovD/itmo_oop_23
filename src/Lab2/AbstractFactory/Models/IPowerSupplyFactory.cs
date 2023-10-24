namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IPowerSupplyFactory : IFactory
{
    public IFactory CustomInstances(string name, int peakLoad);
}