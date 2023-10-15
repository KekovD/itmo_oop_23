using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Other.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entities;

public class CentralProcessor : ICentralProcessor
{
    private readonly ICharacteristic<string> _name;
    private readonly ICharacteristic<int> _coreFrequency;
    private readonly ICharacteristic<int> _coresNumber;
    private readonly ICharacteristic<string> _socket;
    private readonly ICharacteristic<int> _memoryFrequenciesSupported;
    private readonly ICharacteristic<int> _thermalDesignPower;
    private readonly ICharacteristic<int> _powerConsumption;
    private readonly ICharacteristic<bool> _integratedVideoCore;

    public CentralProcessor(
        ICharacteristic<string> name,
        ICharacteristic<int> coreFrequency,
        ICharacteristic<int> coresNumber,
        ICharacteristic<string> socket,
        ICharacteristic<int> memoryFrequenciesSupported,
        ICharacteristic<int> thermalDesignPower,
        ICharacteristic<int> powerConsumption,
        ICharacteristic<bool> integratedVideoCore)
    {
        _name = name;
        _coreFrequency = coreFrequency;
        _coresNumber = coresNumber;
        _socket = socket;
        _memoryFrequenciesSupported = memoryFrequenciesSupported;
        _thermalDesignPower = thermalDesignPower;
        _powerConsumption = powerConsumption;
        _integratedVideoCore = integratedVideoCore;
        Installed = true; //// todo возможно переделать
    }

    public bool Installed { get; protected init; }
}