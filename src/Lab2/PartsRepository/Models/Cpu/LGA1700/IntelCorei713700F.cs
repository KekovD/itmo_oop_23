using Itmo.ObjectOrientedProgramming.Lab2.Socket.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models.Cpu.LGA1700;

public class IntelCorei713700F : CentralProcessorTemplate, ILga1700
{
    private const string? NameConst = "IntelCorei713700F";
    private const int MemoryFrequenciesConst = 5600;
    private const int CoreFrequencyConst = 2100;
    private const int CoresNumberConst = 8;
    private const bool IntegratedVideoCoreConst = false;
    private const int ThermalDesignPowerConst = 219;
    private const int PowerConsumptionConst = 219;

    public IntelCorei713700F()
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