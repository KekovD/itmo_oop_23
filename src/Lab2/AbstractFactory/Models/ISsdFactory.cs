using Itmo.ObjectOrientedProgramming.Lab2.SsdType.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface ISsdFactory : IFactory
{
    public IFactory CustomInstances(
        string name,
        SsdTypeBase connectionOption,
        int capacity,
        int maximumSpeed,
        int powerConsumption);
}