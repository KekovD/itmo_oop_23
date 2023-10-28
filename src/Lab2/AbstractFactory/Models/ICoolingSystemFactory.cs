using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface ICoolingSystemFactory
{
    public ICoolingSystemFactory RepositoryInstances(IList<object> instances);
    public CoolingSystemBase Crate();

    public ICoolingSystemFactory CustomInstances(
        string name,
        int height,
        int width,
        int length,
        IList<SocketBase> supportedSockets,
        int thermalDesignPower);
}