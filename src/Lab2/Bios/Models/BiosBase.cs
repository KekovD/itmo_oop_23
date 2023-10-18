namespace Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;

public abstract class BiosBase
{
    protected BiosBase(int version)
    {
        Version = version;
    }

    public bool BiosValid { get; protected set; } = true;
    public string? Name { get; protected init; }
    public int Version { get; protected init; }
}