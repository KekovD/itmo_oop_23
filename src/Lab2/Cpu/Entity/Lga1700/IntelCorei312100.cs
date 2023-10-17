using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity.Lga1700;

public class IntelCorei312100 : CentralProcessorBase, ILga1700
{
    private const string? NameConst = "IntelCorei312100";
    private const string? SocketConst = "Lga1700";
    private const int MemoryFrequenciesConst = 4800;
    private const int CoreFrequencyConst = 3300;
    private const int CoresNumberConst = 4;
    private const bool IntegratedVideoCoreConst = true;
    private const int ThermalDesignPowerConst = 89;
    private const int PowerConsumptionConst = 89;

    public IntelCorei312100()
    {
        Name = NameConst;
        Socket = SocketConst;
        MemoryFrequencies = MemoryFrequenciesConst;
        CoreFrequency = CoreFrequencyConst;
        CoresNumber = CoresNumberConst;
        IntegratedVideoCore = IntegratedVideoCoreConst;
        ThermalDesignPower = ThermalDesignPowerConst;
        PowerConsumption = PowerConsumptionConst;
    }

    public bool SocketValid { get; } = true;
}