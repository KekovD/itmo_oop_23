using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IPowerSupplyFactory : IFactory
{
    public IPart CreateCustom(string name, int peakLoad);
}