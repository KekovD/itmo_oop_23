using Itmo.ObjectOrientedProgramming.Lab2.Socket.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models.Cpu.LGA1700;

public class IntelCorei312100 : CentralProcessorTemplate, ILga1700
{
    private const string? NameConst = "IntelCorei312100";
    private const int MemoryFrequenciesConst = 4800;
    private const int CoreFrequencyConst = 3300;
    private const int CoresNumberConst = 4;
    private const bool IntegratedVideoCoreConst = true;
    private const int ThermalDesignPowerConst = 89;
    private const int PowerConsumptionConst = 89;

    public IntelCorei312100()
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