using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Xmp.Entities;

public class ExtremeMemoryProfiles : ExtremeMemoryProfilesBase
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

    protected ExtremeMemoryProfiles(
        IReadOnlyList<int> timings,
        int voltage,
        int frequency)
    {
        Timings = new List<int>(timings);
        Voltage = voltage;
        Frequency = frequency;
    }

    public override ExtremeMemoryProfilesBase Clone()
    {
        return new ExtremeMemoryProfiles(
            Timings ?? throw new CloneNullException(nameof(ExtremeMemoryProfilesBase)),
            Voltage,
            Frequency);
    }
}