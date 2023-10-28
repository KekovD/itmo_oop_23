using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

public abstract class XmpJedecBase : IPrototype<XmpJedecBase>
{
    public int Frequency { get; protected init; }
    protected IReadOnlyList<int>? Timings { get; init; }
    protected int Voltage { get; init; }

    public abstract XmpJedecBase Clone();

    public abstract bool HaveXmp();
}