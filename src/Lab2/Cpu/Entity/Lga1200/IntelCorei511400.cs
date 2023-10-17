using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity.Lga1200;

public class IntelCorei511400 : CentralProcessorBase, ILga1200
{
    private const string? NameConst = "IntelCorei511400";
    private const int MemoryFrequenciesConst = 3200;
    private const int CoreFrequencyConst = 2600;
    private const int CoresNumberConst = 6;
    private const bool IntegratedVideoCoreConst = true;
    private const int ThermalDesignPowerConst = 65;
    private const int PowerConsumptionConst = 65;

    public IntelCorei511400()
    {
        Name = NameConst;
        MemoryFrequencies = MemoryFrequenciesConst;
        CoreFrequency = CoreFrequencyConst;
        CoresNumber = CoresNumberConst;
        IntegratedVideoCore = IntegratedVideoCoreConst;
        ThermalDesignPower = ThermalDesignPowerConst;
        PowerConsumption = PowerConsumptionConst;
    }

    public bool SocketValid { get; } = true;
}