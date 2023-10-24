using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class HddFactory : IHddFactory
{
    private string? _name;
    private int _capacity;
    private int _spindleSpeed;
    private int _powerConsumption;

    public IFactory RepositoryInstances(IList<object> instances)
    {
        _name = (string)instances[0];
        _capacity = (int)instances[1];
        _spindleSpeed = (int)instances[2];
        _powerConsumption = (int)instances[3];

        return this;
    }

    public IFactory CustomInstances(
        string name,
        int capacity,
        int spindleSpeed,
        int powerConsumption)
    {
        _name = name;
        _capacity = capacity;
        _spindleSpeed = spindleSpeed;
        _powerConsumption = powerConsumption;

        return this;
    }

    public IPart Crate()
    {
        return new Hdd(
            _name ?? throw new CrateNullException(nameof(HddFactory)),
            _capacity,
            _spindleSpeed,
            _powerConsumption);
    }
}