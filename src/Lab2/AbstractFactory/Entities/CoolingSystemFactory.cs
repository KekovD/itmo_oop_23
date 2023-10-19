using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Entities;

public class CoolingSystemFactory : ICoolingSystemFactory
{
    public IPart CreateByName(string name) =>
        new CoolingSystem(new CoolingSystemRepository().GetByName(name));

    public IPart CreateCustom(
        string name,
        int height,
        int width,
        int length,
        IList<SocketBase> supportedSockets,
        int thermalDesignPower)
    {
        return new CoolingSystem(name, height, width, length, supportedSockets, thermalDesignPower);
    }
}