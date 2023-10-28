using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IPowerSupplyFactory
{
    public IPowerSupplyFactory RepositoryInstances(IList<object> instances);
    public PowerSupplyBase Crate();

    public IPowerSupplyFactory CustomInstances(string name, int peakLoad);
}