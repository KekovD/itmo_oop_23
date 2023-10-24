using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class CentralProcessorFactory : ICentralProcessorFactory
{
    private string? _name;
    private SocketBase? _socket;
    private BiosBase? _bios;
    private int _memoryFrequencies;
    private int _coreFrequency;
    private int _coresNumber;
    private IntegratedVideoCoreBase? _integratedVideoCore;
    private int _thermalDesignPower;
    private int _powerConsumption;

    public IFactory RepositoryInstances(IList<object> instances)
    {
        _name = (string)instances[0];
        _socket = (SocketBase)instances[1];
        _bios = (BiosBase)instances[2];
        _memoryFrequencies = (int)instances[3];
        _coreFrequency = (int)instances[4];
        _coresNumber = (int)instances[5];
        _integratedVideoCore = (IntegratedVideoCoreBase)instances[6];
        _thermalDesignPower = (int)instances[7];
        _powerConsumption = (int)instances[8];

        return this;
    }

    public IFactory CustomInstances(
        string name,
        SocketBase socket,
        BiosBase bios,
        int memoryFrequencies,
        int coreFrequency,
        int coresNumber,
        IntegratedVideoCoreBase integratedVideoCore,
        int thermalDesignPower,
        int powerConsumption)
    {
        _name = name;
        _socket = socket;
        _bios = bios;
        _memoryFrequencies = memoryFrequencies;
        _coreFrequency = coreFrequency;
        _coresNumber = coresNumber;
        _integratedVideoCore = integratedVideoCore;
        _thermalDesignPower = thermalDesignPower;
        _powerConsumption = powerConsumption;

        return this;
    }

    public IPart Crate()
    {
        return new CentralProcessor(
            _name ?? throw new CrateNullException(nameof(CentralProcessorFactory)),
            _socket ?? throw new CrateNullException(nameof(CentralProcessorFactory)),
            _bios ?? throw new CrateNullException(nameof(CentralProcessorFactory)),
            _memoryFrequencies,
            _coreFrequency,
            _coresNumber,
            _integratedVideoCore ?? throw new CrateNullException(nameof(CentralProcessorFactory)),
            _thermalDesignPower,
            _powerConsumption);
    }
}