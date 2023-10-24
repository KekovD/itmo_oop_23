using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Entities;

public class CoolingSystem : CoolingSystemBase
{
    public CoolingSystem(
        string name,
        int height,
        int width,
        int length,
        IList<SocketBase> supportedSockets,
        int thermalDesignPower)
        : base(name, height, width, length, supportedSockets, thermalDesignPower)
    {
    }

    private CoolingSystem(
        string name,
        IReadOnlyList<int> dimensions,
        IReadOnlyList<SocketBase> supportedSockets,
        int thermalDesignPower)
        : base(name, dimensions, supportedSockets, thermalDesignPower)
    {
    }

    public override CoolingSystemBase Clone()
    {
        return new CoolingSystem(
            (string)Name.Clone(),
            new List<int>(Dimensions),
            SupportedSockets.Select(socket => socket.Clone()).ToList(),
            ThermalDesignPower);
    }
}