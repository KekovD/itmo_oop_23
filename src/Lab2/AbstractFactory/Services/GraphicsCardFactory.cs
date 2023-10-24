using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class GraphicsCardFactory : IGraphicsCardFactory
{
    private string? _name;
    private int _height;
    private int _width;
    private int _videoMemoryNumber;
    private PciEVersionBase? _pciEVersion;
    private int _chipFrequency;
    private int _powerConsumption;

    public IFactory RepositoryInstances(IList<object> instances)
    {
        _name = (string)instances[0];
        _height = (int)instances[1];
        _width = (int)instances[2];
        _videoMemoryNumber = (int)instances[3];
        _pciEVersion = (PciEVersionBase)instances[4];
        _chipFrequency = (int)instances[5];
        _powerConsumption = (int)instances[6];

        return this;
    }

    public IFactory CustomInstances(
        string name,
        int height,
        int width,
        int videoMemoryNumber,
        PciEVersionBase pciEVersion,
        int chipFrequency,
        int powerConsumption)
    {
        _name = name;
        _height = height;
        _width = width;
        _videoMemoryNumber = videoMemoryNumber;
        _pciEVersion = pciEVersion;
        _chipFrequency = chipFrequency;
        _powerConsumption = powerConsumption;

        return this;
    }

    public IPart Crate()
    {
        return new GraphicsCard(
            _name ?? throw new CrateNullException(nameof(GraphicsCardFactory)),
            _height,
            _width,
            _videoMemoryNumber,
            _pciEVersion ?? throw new CrateNullException(nameof(GraphicsCardFactory)),
            _chipFrequency,
            _powerConsumption);
    }
}