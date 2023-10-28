using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;

public abstract class CentralProcessorBase : IPowerConsumption, IPrototype<CentralProcessorBase>
{
    protected CentralProcessorBase(
        string name,
        SocketBase socket,
        BiosBase bios,
        int memoryFrequencies,
        int coreFrequency,
        int coresNumber,
        IntegratedVideoCoreBase integratedVideoCore,
        int thermalDesignPower,
        int powerConsumption)
    {
        Name = name;
        Socket = socket;
        Bios = bios;
        MemoryFrequencies = memoryFrequencies;
        CoreFrequency = coreFrequency;
        CoresNumber = coresNumber;
        IntegratedVideoCore = integratedVideoCore;
        ThermalDesignPower = thermalDesignPower;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public SocketBase Socket { get; private set; }
    public BiosBase Bios { get; private set; }
    public int MemoryFrequencies { get; private set; }
    public int CoreFrequency { get; private set; }
    public int CoresNumber { get; private set; }
    public IntegratedVideoCoreBase IntegratedVideoCore { get; private set; }
    public int ThermalDesignPower { get; private set; }
    public int PowerConsumption { get; }

    public abstract CentralProcessorBase Clone();
}