using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;

public abstract class HddBase : IPowerConsumption, IPrototype<HddBase>
{
    protected HddBase(
        string name,
        int capacity,
        int spindleSpeed,
        int powerConsumption)
    {
        Name = name;
        Capacity = capacity;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public int Capacity { get; private set; }
    public int SpindleSpeed { get; private set; }
    public int PowerConsumption { get; }

    public abstract HddBase Clone();
}