using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Models;

public abstract class RamFormFactorBase : IPrototype<RamFormFactorBase>
{
    public string? Name { get; protected set; }

    public abstract RamFormFactorBase Clone();
}