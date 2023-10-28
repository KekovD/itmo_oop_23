using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Xmp.Entities;

public class ExtremeMemoryProfiles : XmpJedecBase
{
    public ExtremeMemoryProfiles(
        int rasToCas,
        int rasPrecharge,
        int tRas,
        int tRc,
        int voltage,
        int frequency)
    {
        Timings = new List<int>
        {
            rasToCas,
            rasPrecharge,
            tRas,
            tRc,
        };

        Voltage = voltage;
        Frequency = frequency;
    }

    private ExtremeMemoryProfiles(
        IReadOnlyList<int> timings,
        int voltage,
        int frequency)
    {
        Timings = new List<int>(timings);
        Voltage = voltage;
        Frequency = frequency;
    }

    public override XmpJedecBase Clone()
    {
        return new ExtremeMemoryProfiles(
            Timings ?? throw new CloneNullException(nameof(XmpJedecBase)),
            Voltage,
            Frequency);
    }

    public override bool HaveXmp() => true;
}