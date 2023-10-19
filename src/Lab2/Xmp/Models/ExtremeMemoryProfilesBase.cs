using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

public abstract class ExtremeMemoryProfilesBase : IPrototype<ExtremeMemoryProfilesBase>
{
    protected ExtremeMemoryProfilesBase(
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

    protected ExtremeMemoryProfilesBase(
        IReadOnlyList<int> timings,
        int voltage,
        int frequency)
    {
        Timings = new List<int>(timings);
        Voltage = voltage;
        Frequency = frequency;
    }

    public IReadOnlyList<int> Timings { get; protected set; }
    public int Voltage { get; protected set; }
    public int Frequency { get; protected set; }

    public abstract ExtremeMemoryProfilesBase Clone();
    public abstract ExtremeMemoryProfilesBase CloneWithNewTimings(int rasToCas, int rasPrecharge, int tRas, int tRc);
    public abstract ExtremeMemoryProfilesBase CloneWithNewVoltage(int voltage);
    public abstract ExtremeMemoryProfilesBase CloneWithNewFrequency(int frequency); //// Todo продолжить здесь, эти 3 реализовать тут же
}