using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdType.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;

public abstract class SsdBase : IPowerConsumption, IPrototype<SsdBase>
{
    protected SsdBase(
        string name,
        SsdTypeBase connectionOption,
        int capacity,
        int maximumSpeed,
        int powerConsumption)
    {
        Name = name;
        ConnectionOption = connectionOption;
        Capacity = capacity;
        MaximumSpeed = maximumSpeed;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public SsdTypeBase ConnectionOption { get; private set; }
    public int Capacity { get; private set; }
    public int MaximumSpeed { get; private set; }
    public int PowerConsumption { get; }

    public abstract SsdBase Clone();
}