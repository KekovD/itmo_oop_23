using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Entity;

public class CentralProcessorFactory : ICentralProcessorFactory
{
    public IPart CreateByName(string name)
    {
        return new CentralProcessor(new CentralProcessorRepository().GetByName(name));
    }

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
        var processor = new CentralProcessor(
            name,
            socket,
            bios,
            memoryFrequencies,
            coreFrequency,
            coresNumber,
            integratedVideoCore,
            thermalDesignPower,
            powerConsumption);

        new CentralProcessorRepository().Add(processor);

        return processor;
    }
}