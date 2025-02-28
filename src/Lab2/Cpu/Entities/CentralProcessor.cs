﻿using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entities;

public class CentralProcessor : CentralProcessorBase
{
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
            (string)Name.Clone(),
            Socket.Clone(),
            Bios.Clone(),
            MemoryFrequencies,
            CoreFrequency,
            CoresNumber,
            IntegratedVideoCore.Clone(),
            ThermalDesignPower,
            PowerConsumption);
    }
}