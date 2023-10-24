using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;

public abstract class PowerSupplyBase : IPart, IPrototype<PowerSupplyBase>
{
    protected PowerSupplyBase(string name, int peakLoad)
    {
        Name = name;
        PeakLoad = peakLoad;
    }

    public string Name { get; private set; }
    public int PeakLoad { get; private set; }

    public abstract PowerSupplyBase Clone();

    public PowerSupplyBase CloneWithNewName(string name)
    {
        PowerSupplyBase clone = Clone();
        clone.Name = name;

        return clone;
    }

    public PowerSupplyBase CloneWithNewPeakLoad(int peakLoad)
    {
        PowerSupplyBase clone = Clone();
        clone.PeakLoad = peakLoad;

        return clone;
    }
}