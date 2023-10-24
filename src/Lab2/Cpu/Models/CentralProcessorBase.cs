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

    public string Name { get; private set; }
    public SocketBase Socket { get; private set; }
    public BiosBase Bios { get; private set; }
    public int MemoryFrequencies { get; private set; }
    public int CoreFrequency { get; private set; }
    public int CoresNumber { get; private set; }
    public IntegratedVideoCoreBase IntegratedVideoCore { get; private set; }
    public int ThermalDesignPower { get; private set; }
    public int PowerConsumption { get; private set; }

    public abstract CentralProcessorBase Clone();

    public CentralProcessorBase CloneWithNewName(string name)
    {
        CentralProcessorBase clone = Clone();
        clone.Name = name;

        return clone;
    }

    public CentralProcessorBase CloneWithNewSocket(SocketBase socket)
    {
        CentralProcessorBase clone = Clone();
        clone.Socket = socket;

        return clone;
    }

    public CentralProcessorBase CloneWithNewBios(BiosBase bios)
    {
        CentralProcessorBase clone = Clone();
        clone.Bios = bios;

        return clone;
    }

    public CentralProcessorBase CloneWithNewMemoryFrequencies(int memoryFrequencies)
    {
        CentralProcessorBase clone = Clone();
        clone.MemoryFrequencies = memoryFrequencies;

        return clone;
    }

    public CentralProcessorBase CloneWithNewCoreFrequency(int coreFrequency)
    {
        CentralProcessorBase clone = Clone();
        clone.CoreFrequency = coreFrequency;

        return clone;
    }

    public CentralProcessorBase CloneWithNewCoreCoresNumber(int coresNumber)
    {
        CentralProcessorBase clone = Clone();
        clone.CoresNumber = coresNumber;

        return clone;
    }

    public CentralProcessorBase CloneWithNewIntegratedVideoCore(IntegratedVideoCoreBase integratedVideoCore)
    {
        CentralProcessorBase clone = Clone();
        clone.IntegratedVideoCore = integratedVideoCore;

        return clone;
    }

    public CentralProcessorBase CloneWithNewThermalDesignPower(int thermalDesignPower)
    {
        CentralProcessorBase clone = Clone();
        clone.ThermalDesignPower = thermalDesignPower;

        return clone;
    }

    public CentralProcessorBase CloneWithNewPowerConsumption(int powerConsumption)
    {
        CentralProcessorBase clone = Clone();
        clone.PowerConsumption = powerConsumption;

        return clone;
    }
}