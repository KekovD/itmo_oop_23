using System.Collections.Generic;
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

    protected SsdBase(IList<object> characteristics)
    {
        Name = (string)characteristics[0];
        ConnectionOption = (SsdTypeBase)characteristics[1];
        Capacity = (int)characteristics[2];
        MaximumSpeed = (int)characteristics[3];
        PowerConsumption = (int)characteristics[4];
    }

    public bool PartValid { get; protected set; } = true;
    public bool WarrantyDisclaimer { get; protected set; }
    public string Name { get; private set; }
    public SsdTypeBase ConnectionOption { get; private set; }
    public int Capacity { get; private set; }
    public int MaximumSpeed { get; private set; }
    public int PowerConsumption { get; private set; }

    public abstract SsdBase Clone();

    public SsdBase CloneWithNewName(string name)
    {
        SsdBase clone = Clone();
        clone.Name = name;

        return clone;
    }

    public SsdBase CloneWithNewConnectionOption(SsdTypeBase connectionOption)
    {
        SsdBase clone = Clone();
        clone.ConnectionOption = connectionOption;

        return clone;
    }

    public SsdBase CloneWithNewCapacity(int capacity)
    {
        SsdBase clone = Clone();
        clone.Capacity = capacity;

        return clone;
    }

    public SsdBase CloneWithNewMaximumSpeed(int maximumSpeed)
    {
        SsdBase clone = Clone();
        clone.MaximumSpeed = maximumSpeed;

        return clone;
    }

    public SsdBase CloneWithNewPowerConsumption(int powerConsumption)
    {
        SsdBase clone = Clone();
        clone.PowerConsumption = powerConsumption;

        return clone;
    }
}