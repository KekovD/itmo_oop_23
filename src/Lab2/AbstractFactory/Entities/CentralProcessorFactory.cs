using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Entities;

public class CentralProcessorFactory : ICentralProcessorFactory
{
    public IPart CreateByName(string name) =>
        new CentralProcessor(new CentralProcessorRepository().GetByName(name));

    public IPart CreateCustom(
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
        return new CentralProcessor(
            name,
            socket,
            bios,
            memoryFrequencies,
            coreFrequency,
            coresNumber,
            integratedVideoCore,
            thermalDesignPower,
            powerConsumption);
    }
}