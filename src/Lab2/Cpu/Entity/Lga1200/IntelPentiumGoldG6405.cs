using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity.Lga1200;

public class IntelPentiumGoldG6405 : CentralProcessorBase, ILga1200
{
    private const string? NameConst = "IntelPentiumGoldG6405";
    private const int MemoryFrequenciesConst = 2666;
    private const int CoreFrequencyConst = 4100;
    private const int CoresNumberConst = 2;
    private const bool IntegratedVideoCoreConst = true;
    private const int ThermalDesignPowerConst = 58;
    private const int PowerConsumptionConst = 58;

    public IntelPentiumGoldG6405()
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