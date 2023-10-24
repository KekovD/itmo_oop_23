using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.IntegratedWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class MotherboardFactory : IMotherboardFactory
{
    private string? _name;
    private SocketBase? _socket;
    private int _pciENumber;
    private int _sataNumber;
    private int _memoryFrequencies;
    private XmpJedecBase? _extremeMemoryProfiles;
    private DdrMotherboardBase? _ddrMotherboard;
    private int _ramTablesNumber;
    private FormFactorMotherboardBase? _formFactor;
    private BiosBase? _bios;
    private PciEVersionBase? _pciEVersion;
    private IIntegratedWiFi? _integratedWiFi;

    public IFactory RepositoryInstances(IList<object> instances)
    {
        _name = (string)instances[0];
        _socket = (SocketBase)instances[1];
        _pciENumber = (int)instances[2];
        _sataNumber = (int)instances[3];
        _memoryFrequencies = (int)instances[4];
        _extremeMemoryProfiles = (XmpJedecBase)instances[5];
        _ddrMotherboard = (DdrMotherboardBase)instances[6];
        _ramTablesNumber = (int)instances[7];
        _formFactor = (FormFactorMotherboardBase)instances[8];
        _bios = (BiosBase)instances[9];
        _pciEVersion = (PciEVersionBase)instances[10];
        _integratedWiFi = (IIntegratedWiFi)instances[11];

        return this;
    }

    public IFactory CustomInstances(
        string name,
        SocketBase socket,
        int pciENumber,
        int sataNumber,
        int memoryFrequencies,
        XmpJedecBase extremeMemoryProfiles,
        DdrMotherboardBase ddrMotherboard,
        int ramTablesNumber,
        FormFactorMotherboardBase formFactor,
        BiosBase bios,
        PciEVersionBase pciEVersion,
        IIntegratedWiFi integratedWiFi)
    {
        _name = name;
        _socket = socket;
        _pciENumber = pciENumber;
        _sataNumber = sataNumber;
        _memoryFrequencies = memoryFrequencies;
        _extremeMemoryProfiles = extremeMemoryProfiles;
        _ddrMotherboard = ddrMotherboard;
        _ramTablesNumber = ramTablesNumber;
        _formFactor = formFactor;
        _bios = bios;
        _pciEVersion = pciEVersion;
        _integratedWiFi = integratedWiFi;

        return this;
    }

    public IPart Crate()
    {
        return new Motherboard(
            _name ?? throw new CrateNullException(nameof(MotherboardFactory)),
            _socket ?? throw new CrateNullException(nameof(MotherboardFactory)),
            _pciENumber,
            _sataNumber,
            _memoryFrequencies,
            _extremeMemoryProfiles ?? throw new CrateNullException(nameof(MotherboardFactory)),
            _ddrMotherboard ?? throw new CrateNullException(nameof(MotherboardFactory)),
            _ramTablesNumber,
            _formFactor ?? throw new CrateNullException(nameof(MotherboardFactory)),
            _bios ?? throw new CrateNullException(nameof(MotherboardFactory)),
            _pciEVersion ?? throw new CrateNullException(nameof(MotherboardFactory)),
            _integratedWiFi ?? throw new CrateNullException(nameof(MotherboardFactory)));
    }
}