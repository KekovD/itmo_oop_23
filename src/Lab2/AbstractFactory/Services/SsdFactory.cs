using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.SsdType.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class SsdFactory : ISsdFactory
{
    private string? _name;
    private SsdTypeBase? _connectionOption;
    private int _capacity;
    private int _maximumSpeed;
    private int _powerConsumption;

    public IFactory RepositoryInstances(IList<object> instances)
    {
        _name = (string)instances[0];
        _connectionOption = (SsdTypeBase)instances[1];
        _capacity = (int)instances[2];
        _maximumSpeed = (int)instances[3];
        _powerConsumption = (int)instances[4];

        return this;
    }

    public IFactory CustomInstances(
        string name,
        SsdTypeBase connectionOption,
        int capacity,
        int maximumSpeed,
        int powerConsumption)
    {
        _name = name;
        _connectionOption = connectionOption;
        _capacity = capacity;
        _maximumSpeed = maximumSpeed;
        _powerConsumption = powerConsumption;

        return this;
    }

    public IPart Crate()
    {
        return new Ssd(
            _name ?? throw new CrateNullException(nameof(SsdFactory)),
            _connectionOption ?? throw new CrateNullException(nameof(SsdFactory)),
            _capacity,
            _maximumSpeed,
            _powerConsumption);
    }
}