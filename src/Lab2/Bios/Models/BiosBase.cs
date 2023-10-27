using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;

public abstract class BiosBase : IPrototype<BiosBase>
{
    protected BiosBase(int version)
    {
        Version = version;
    }

    public bool BiosValid { get; protected set; } = true;
    public string? Name { get; protected init; }
    public int Version { get; private set; }

    public abstract BiosBase Clone();

    public abstract bool CompareBios(BiosBase bios);
}