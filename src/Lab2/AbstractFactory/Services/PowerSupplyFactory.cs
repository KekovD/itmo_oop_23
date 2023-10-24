using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class PowerSupplyFactory : IPowerSupplyFactory
{
    private string? _name;
    private int _peakLoad;

    public IFactory RepositoryInstances(IList<object> instances)
    {
        _name = (string)instances[0];
        _peakLoad = (int)instances[1];

        return this;
    }

    public IFactory CustomInstances(string name, int peakLoad)
    {
        _name = name;
        _peakLoad = peakLoad;

        return this;
    }

    public IPart Crate()
    {
        return new PowerSupply(
            _name ?? throw new CrateNullException(nameof(PowerSupplyFactory)),
            _peakLoad);
    }
}