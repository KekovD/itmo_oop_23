using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdType.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface ISsdFactory
{
    public ISsdFactory RepositoryInstances(IList<object> instances);
    public SsdBase Crate();

    public ISsdFactory CustomInstances(
        string name,
        SsdTypeBase connectionOption,
        int capacity,
        int maximumSpeed,
        int powerConsumption);
}