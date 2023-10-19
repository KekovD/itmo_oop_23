using System.Collections.Generic;
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
        : base(rasToCas, rasPrecharge, tRas, tRc, voltage, frequency)
    {
    }

    private ExtremeMemoryProfiles(
        IReadOnlyList<int> timings,
        int voltage,
        int frequency)
        : base(timings, voltage, frequency)
    {
    }

    public override ExtremeMemoryProfilesBase Clone()
    {
        return new ExtremeMemoryProfiles(
            this.Timings,
            this.Voltage,
            this.Frequency);
    }
}