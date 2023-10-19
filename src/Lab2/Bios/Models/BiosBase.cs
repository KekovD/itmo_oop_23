using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;

public abstract class BiosBase : IPrototype<BiosBase>
{
    protected BiosBase(int version)
    {
        Version = version;
    }

    public bool BiosValid { get; protected set; } = true;
    public string? Name { get; protected set; }
    public int Version { get; protected set; }

    public abstract BiosBase Clone();

    public BiosBase CloneWithNewVersion(int version)
    {
        BiosBase clone = Clone();
        clone.Version = version;

        return clone;
    }
}