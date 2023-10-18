using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Model;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;

public abstract class CentralProcessorBase : IPart, IPrototype<CentralProcessorBase>
{
    protected CentralProcessorBase(IList<object> characteristics)
    {
        Name = (string)characteristics[0];
        Socket = (SocketBase)characteristics[1];
        Bios = (BiosBase)characteristics[2];
        MemoryFrequencies = (int)characteristics[3];
        CoreFrequency = (int)characteristics[4];
        CoresNumber = (int)characteristics[5];
        IntegratedVideoCore = (IntegratedVideoCoreBase)characteristics[6];
        ThermalDesignPower = (int)characteristics[7];
        PowerConsumption = (int)characteristics[8];
    }

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

    public bool PartValid { get; private set; } = true;
    public bool WarrantyDisclaimer { get; private set; }
    public string Name { get; protected set; }
    public SocketBase Socket { get; protected set; }
    public BiosBase Bios { get; protected set; }
    public int MemoryFrequencies { get; protected set; }
    public int CoreFrequency { get; protected set; }
    public int CoresNumber { get; protected set; }
    public IntegratedVideoCoreBase IntegratedVideoCore { get; protected set; }
    public int ThermalDesignPower { get; protected set; }
    public int PowerConsumption { get; protected set; }

    public abstract CentralProcessorBase Clone();
    public abstract CentralProcessorBase CloneWithNewName(string name);
    public abstract CentralProcessorBase CloneWithNewSocket(SocketBase socket);
    public abstract CentralProcessorBase CloneWithNewBios(BiosBase bios);
    public abstract CentralProcessorBase CloneWithNewMemoryFrequencies(int memoryFrequencies);
    public abstract CentralProcessorBase CloneWithNewCoreFrequency(int coreFrequency);
    public abstract CentralProcessorBase CloneWithNewCoreCoresNumber(int coresNumber);
    public abstract CentralProcessorBase CloneWithNewIntegratedVideoCore(IntegratedVideoCoreBase integratedVideoCore);
    public abstract CentralProcessorBase CloneWithNewThermalDesignPower(int thermalDesignPower);
    public abstract CentralProcessorBase CloneWithNewPowerConsumption(int powerConsumption);
}