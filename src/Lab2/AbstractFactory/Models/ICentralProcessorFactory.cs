using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface ICentralProcessorFactory : IFactory
{
    public IPart CreateCustom(
        string name,
        SocketBase socket,
        BiosBase bios,
        int memoryFrequencies,
        int coreFrequency,
        int coresNumber,
        IntegratedVideoCoreBase integratedVideoCore,
        int thermalDesignPower,
        int powerConsumption);
}