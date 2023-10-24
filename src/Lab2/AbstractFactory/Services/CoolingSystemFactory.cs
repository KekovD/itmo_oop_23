using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class CoolingSystemFactory : ICoolingSystemFactory
{
    private string? _name;
    private int _height;
    private int _width;
    private int _length;
    private IList<SocketBase>? _supportedSockets;
    private int _thermalDesignPower;

    public IFactory RepositoryInstances(IList<object> instances)
    {
        _name = (string)instances[0];
        var dimensions = (List<int>)instances[1];
        _height = dimensions[0];
        _width = dimensions[1];
        _length = dimensions[2];
        _supportedSockets = (List<SocketBase>)instances[2];
        _thermalDesignPower = (int)instances[3];

        return this;
    }

    public IFactory CustomInstances(
        string name,
        int height,
        int width,
        int length,
        IList<SocketBase> supportedSockets,
        int thermalDesignPower)
    {
        _name = name;
        _height = height;
        _width = width;
        _length = length;
        _supportedSockets = supportedSockets;
        _thermalDesignPower = thermalDesignPower;

        return this;
    }

    public IPart Crate()
    {
        return new CoolingSystem(
            _name ?? throw new CrateNullException(nameof(CoolingSystemFactory)),
            _height,
            _width,
            _length,
            _supportedSockets ?? throw new CrateNullException(nameof(CoolingSystemFactory)),
            _thermalDesignPower);
    }
}