using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;

public class CentralProcessor : CentralProcessorBase
{
    public CentralProcessor(IList<object> characteristics)
        : base(characteristics)
    {
    }

    public CentralProcessor(
        string name,
        SocketBase socket,
        BiosBase bios,
        int memoryFrequencies,
        int coreFrequency,
        int coresNumber,
        IntegratedVideoCoreBase integratedVideoCore,
        int thermalDesignPower,
        int powerConsumption)
        : base(name, socket, bios, memoryFrequencies, coreFrequency, coresNumber, integratedVideoCore, thermalDesignPower, powerConsumption)
    {
    }

    public override CentralProcessor Clone()
    {
        return new CentralProcessor(
            this.Name,
            this.Socket,
            this.Bios,
            this.MemoryFrequencies,
            this.CoreFrequency,
            this.CoresNumber,
            this.IntegratedVideoCore,
            this.ThermalDesignPower,
            this.PowerConsumption);
    }

    public override CentralProcessorBase CloneWithNewName(string name)
    {
        CentralProcessor clone = Clone();
        clone.Name = name;

        return clone;
    }

    public override CentralProcessorBase CloneWithNewSocket(SocketBase socket)
    {
        CentralProcessor clone = Clone();
        clone.Socket = socket;

        return clone;
    }

    public override CentralProcessorBase CloneWithNewBios(BiosBase bios)
    {
        CentralProcessor clone = Clone();
        clone.Bios = bios;

        return clone;
    }

    public override CentralProcessorBase CloneWithNewMemoryFrequencies(int memoryFrequencies)
    {
        CentralProcessor clone = Clone();
        clone.MemoryFrequencies = memoryFrequencies;

        return clone;
    }

    public override CentralProcessorBase CloneWithNewCoreFrequency(int coreFrequency)
    {
        CentralProcessor clone = Clone();
        clone.CoreFrequency = coreFrequency;

        return clone;
    }

    public override CentralProcessorBase CloneWithNewCoreCoresNumber(int coresNumber)
    {
        CentralProcessor clone = Clone();
        clone.CoresNumber = coresNumber;

        return clone;
    }

    public override CentralProcessorBase CloneWithNewIntegratedVideoCore(IntegratedVideoCoreBase integratedVideoCore)
    {
        CentralProcessor clone = Clone();
        clone.IntegratedVideoCore = integratedVideoCore;

        return clone;
    }

    public override CentralProcessorBase CloneWithNewThermalDesignPower(int thermalDesignPower)
    {
        CentralProcessor clone = Clone();
        clone.ThermalDesignPower = thermalDesignPower;

        return clone;
    }

    public override CentralProcessorBase CloneWithNewPowerConsumption(int powerConsumption)
    {
        CentralProcessor clone = Clone();
        clone.PowerConsumption = powerConsumption;

        return clone;
    }
}