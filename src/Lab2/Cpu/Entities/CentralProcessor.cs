using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entities;

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

    public override CentralProcessorBase Clone()
    {
        return new CentralProcessor(
            this.Name,
            this.Socket.Clone(),
            this.Bios.Clone(),
            this.MemoryFrequencies,
            this.CoreFrequency,
            this.CoresNumber,
            this.IntegratedVideoCore.Clone(),
            this.ThermalDesignPower,
            this.PowerConsumption);
    }
}