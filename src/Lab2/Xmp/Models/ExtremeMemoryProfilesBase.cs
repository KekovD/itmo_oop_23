using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

public abstract class ExtremeMemoryProfilesBase : IPrototype<ExtremeMemoryProfilesBase>
{
    public IReadOnlyList<int>? Timings { get; protected set; }
    public int Voltage { get; protected set; }
    public int Frequency { get; protected set; }

    public abstract ExtremeMemoryProfilesBase Clone();

    public ExtremeMemoryProfilesBase CloneWithNewTimings(int rasToCas, int rasPrecharge, int tRas, int tRc)
    {
        var newTimings = new List<int>
        {
            rasToCas,
            rasPrecharge,
            tRas,
            tRc,
        };

        ExtremeMemoryProfilesBase clone = Clone();
        clone.Timings = newTimings;

        return clone;
    }

    public ExtremeMemoryProfilesBase CloneWithNewVoltage(int voltage)
    {
        ExtremeMemoryProfilesBase clone = Clone();
        clone.Voltage = voltage;

        return clone;
    }

    public ExtremeMemoryProfilesBase CloneWithNewFrequency(int frequency)
    {
        ExtremeMemoryProfilesBase clone = Clone();
        clone.Frequency = frequency;

        return clone;
    }
}