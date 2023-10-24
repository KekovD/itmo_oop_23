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

    public string Name { get; private set; }
    public int Capacity { get; private set; }
    public int SpindleSpeed { get; private set; }
    public int PowerConsumption { get; private set; }

    public abstract HddBase Clone();

    public HddBase CloneWithNewName(string name)
    {
        HddBase clone = Clone();
        clone.Name = name;

        return clone;
    }

    public HddBase CloneWithNewCapacity(int capacity)
    {
        HddBase clone = Clone();
        clone.Capacity = capacity;

        return clone;
    }

    public HddBase CloneWithNewSpindleSpeed(int spindleSpeed)
    {
        HddBase clone = Clone();
        clone.SpindleSpeed = spindleSpeed;

        return clone;
    }

    public HddBase CloneWithNewPowerConsumption(int powerConsumption)
    {
        HddBase clone = Clone();
        clone.PowerConsumption = powerConsumption;

        return clone;
    }
}