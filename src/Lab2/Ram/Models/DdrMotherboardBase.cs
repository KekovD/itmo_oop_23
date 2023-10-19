using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

public abstract class DdrMotherboardBase : IPrototype<DdrMotherboardBase>
{
    public string? Name { get; protected set; }

    public abstract DdrMotherboardBase Clone();
}