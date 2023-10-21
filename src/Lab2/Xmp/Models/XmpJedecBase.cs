using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

public abstract class XmpJedecBase : IPrototype<XmpJedecBase>
{
    public IReadOnlyList<int>? Timings { get; protected set; }
    public int Voltage { get; protected set; }
    public int Frequency { get; protected set; }

    public abstract XmpJedecBase Clone();

    public XmpJedecBase CloneWithNewTimings(int rasToCas, int rasPrecharge, int tRas, int tRc)
    {
        var newTimings = new List<int>
        {
            rasToCas,
            rasPrecharge,
            tRas,
            tRc,
        };

        XmpJedecBase clone = Clone();
        clone.Timings = newTimings;

        return clone;
    }

    public XmpJedecBase CloneWithNewVoltage(int voltage)
    {
        XmpJedecBase clone = Clone();
        clone.Voltage = voltage;

        return clone;
    }

    public XmpJedecBase CloneWithNewFrequency(int frequency)
    {
        XmpJedecBase clone = Clone();
        clone.Frequency = frequency;

        return clone;
    }

    public abstract bool HaveXmp();
}