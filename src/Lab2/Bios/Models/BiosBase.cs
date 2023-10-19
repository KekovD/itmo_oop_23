using Itmo.ObjectOrientedProgramming.Lab2.LabException;
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

    public BiosBase Clone() =>
        new Entities.Bios(
            this.Name ?? throw new CloneNullException(nameof(BiosBase)),
            this.Version);

    public BiosBase CloneWithNewName(string name)
    {
        BiosBase clone = Clone();
        clone.Name = name;

        return clone;
    }

    public BiosBase CloneWithNewVersion(int version)
    {
        BiosBase clone = Clone();
        clone.Version = version;

        return clone;
    }
}