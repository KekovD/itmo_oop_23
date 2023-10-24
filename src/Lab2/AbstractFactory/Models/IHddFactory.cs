using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IHddFactory
{
    public IHddFactory RepositoryInstances(IList<object> instances);
    public HddBase Crate();

    public IHddFactory CustomInstances(
        string name,
        int capacity,
        int spindleSpeed,
        int powerConsumption);
}