using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models.Characteristic;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.Other.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Builder;

public class CentralProcessorBuilder : ICentralProcessorBuilder
{
    private ICharacteristic<string>? _name;
    private ICharacteristic<int>? _coreFrequency;
    private ICharacteristic<int>? _coresNumber;
    private ICharacteristic<string>? _socket;
    private ICharacteristic<int>? _memoryFrequenciesSupported;
    private ICharacteristic<int>? _thermalDesignPower;
    private ICharacteristic<int>? _powerConsumption;
    private ICharacteristic<bool> _integratedVideoCore = new IntegratedVideoCore();

    public ICentralProcessorBuilder Name(ICharacteristic<string> characteristic)
    {
        _name = characteristic;
        return this;
    }

    public ICentralProcessorBuilder CoreFrequency(ICharacteristic<int> characteristic)
    {
        _coreFrequency = characteristic;
        return this;
    }

    public ICentralProcessorBuilder CoresNumbers(ICharacteristic<int> characteristic)
    {
        _coresNumber = characteristic;
        return this;
    }

    public ICentralProcessorBuilder Socket(ICharacteristic<string> characteristic)
    {
        _socket = characteristic;
        return this;
    }

    public ICentralProcessorBuilder MemoryFrequenciesSupported(ICharacteristic<int> characteristic)
    {
        _memoryFrequenciesSupported = characteristic;
        return this;
    }

    public ICentralProcessorBuilder ThermalDesignPower(ICharacteristic<int> characteristic)
    {
        _thermalDesignPower = characteristic;
        return this;
    }

    public ICentralProcessorBuilder PowerConsumption(ICharacteristic<int> characteristic)
    {
        _powerConsumption = characteristic;
        return this;
    }

    public ICentralProcessorBuilder IntegratedVideoCore(ICharacteristic<bool> characteristic)
    {
        _integratedVideoCore = characteristic;
        return this;
    }

    public ICentralProcessor Create()
    {
        return new CentralProcessor(
            _name ?? throw new CharacteristicNullException(nameof(_name)),
            _coreFrequency ?? throw new CharacteristicNullException(nameof(_coreFrequency)),
            _coresNumber ?? throw new CharacteristicNullException(nameof(_coresNumber)),
            _socket ?? throw new CharacteristicNullException(nameof(_socket)),
            _memoryFrequenciesSupported ?? throw new CharacteristicNullException(nameof(_memoryFrequenciesSupported)),
            _thermalDesignPower ?? throw new CharacteristicNullException(nameof(_thermalDesignPower)),
            _powerConsumption ?? throw new CharacteristicNullException(nameof(_powerConsumption)),
            _integratedVideoCore);
    }
}