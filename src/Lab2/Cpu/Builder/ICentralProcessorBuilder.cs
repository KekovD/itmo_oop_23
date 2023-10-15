using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Other.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Builder;

public interface ICentralProcessorBuilder
{
    ICentralProcessorBuilder Name(ICharacteristic<string> characteristic);

    ICentralProcessorBuilder CoreFrequency(ICharacteristic<int> characteristic);

    ICentralProcessorBuilder CoresNumbers(ICharacteristic<int> characteristic);

    ICentralProcessorBuilder Socket(ICharacteristic<string> characteristic);

    ICentralProcessorBuilder MemoryFrequenciesSupported(ICharacteristic<int> characteristic);

    ICentralProcessorBuilder ThermalDesignPower(ICharacteristic<int> characteristic);

    ICentralProcessorBuilder PowerConsumption(ICharacteristic<int> characteristic);

    ICentralProcessorBuilder IntegratedVideoCore(ICharacteristic<bool> characteristic);

    ICentralProcessor Create();
}