using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;

public abstract class CoolingSystemBase : IPart, IPrototype<CoolingSystemBase>
{
    protected CoolingSystemBase(
        string name,
        int height,
        int width,
        int length,
        IList<SocketBase> supportedSockets,
        int thermalDesignPower)
    {
        Name = name;
        Dimensions = new List<int> { height, width, length, };
        SupportedSockets = new List<SocketBase>(supportedSockets);
        ThermalDesignPower = thermalDesignPower;
    }

    protected CoolingSystemBase(
        string name,
        IReadOnlyList<int> dimensions,
        IReadOnlyList<SocketBase> supportedSockets,
        int thermalDesignPower)
    {
        Name = name;
        Dimensions = new List<int>(dimensions);
        SupportedSockets = new List<SocketBase>(supportedSockets);
        ThermalDesignPower = thermalDesignPower;
    }

    public string Name { get; private set; }
    public IReadOnlyList<int> Dimensions { get; private set; }
    public IReadOnlyList<SocketBase> SupportedSockets { get; private set; }
    public int ThermalDesignPower { get; private set; }

    public abstract CoolingSystemBase Clone();

    public CoolingSystemBase CloneWithNewName(string name)
    {
        CoolingSystemBase clone = Clone();
        clone.Name = name;

        return clone;
    }

    public CoolingSystemBase CloneWithNewDimensions(int height, int width, int length)
    {
        CoolingSystemBase clone = Clone();
        clone.Dimensions = new List<int> { height, width, length };

        return clone;
    }

    public CoolingSystemBase CloneWithNewSupportedSockets(IList<SocketBase> supportedSockets)
    {
        CoolingSystemBase clone = Clone();
        clone.SupportedSockets = new List<SocketBase>(supportedSockets);

        return clone;
    }

    public CoolingSystemBase CloneWithAddSupportedSocket(SocketBase supportedSocket)
    {
        CoolingSystemBase clone = Clone();
        clone.SupportedSockets = new List<SocketBase>(SupportedSockets) { supportedSocket };

        return clone;
    }

    public CoolingSystemBase CloneWithNewThermalDesignPower(int thermalDesignPower)
    {
        CoolingSystemBase clone = Clone();
        clone.ThermalDesignPower = thermalDesignPower;

        return clone;
    }
}