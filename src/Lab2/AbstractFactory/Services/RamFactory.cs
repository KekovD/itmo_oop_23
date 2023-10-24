using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class RamFactory : IRamFactory
{
    private string? _name;
    private int _memorySize;
    private int _cardsNumber;
    private Jedec? _jedecProfile;
    private XmpJedecBase? _extremeMemoryProfile;
    private RamFormFactorBase? _ramFormFactor;
    private DdrMotherboardBase? _ddrType;
    private int _powerConsumption;

    public IRamFactory RepositoryInstances(IList<object> instances)
    {
        _name = (string)instances[0];
        _memorySize = (int)instances[1];
        _cardsNumber = (int)instances[2];
        _jedecProfile = (Jedec)instances[3];
        _extremeMemoryProfile = (XmpJedecBase)instances[4];
        _ramFormFactor = (RamFormFactorBase)instances[5];
        _ddrType = (DdrMotherboardBase)instances[6];
        _powerConsumption = (int)instances[7];

        return this;
    }

    public IRamFactory CustomInstances(
        string name,
        int memorySize,
        int cardsNumber,
        Jedec jedecProfile,
        XmpJedecBase extremeMemoryProfile,
        RamFormFactorBase ramFormFactor,
        DdrMotherboardBase ddrType,
        int powerConsumption)
    {
        _name = name;
        _memorySize = memorySize;
        _cardsNumber = cardsNumber;
        _jedecProfile = jedecProfile;
        _extremeMemoryProfile = extremeMemoryProfile;
        _ramFormFactor = ramFormFactor;
        _ddrType = ddrType;
        _powerConsumption = powerConsumption;

        return this;
    }

    public RamBase Crate()
    {
        return new Ram.Entities.Ram(
            _name ?? throw new CrateNullException(nameof(RamFactory)),
            _memorySize,
            _cardsNumber,
            _jedecProfile ?? throw new CrateNullException(nameof(RamFactory)),
            _extremeMemoryProfile ?? throw new CrateNullException(nameof(RamFactory)),
            _ramFormFactor ?? throw new CrateNullException(nameof(RamFactory)),
            _ddrType ?? throw new CrateNullException(nameof(RamFactory)),
            _powerConsumption);
    }
}