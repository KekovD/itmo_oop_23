using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Models;

public abstract class RamFormFactorBase : IPrototype<RamFormFactorBase>
{
    protected RamFormFactorBase(string name)
    {
        Name = name;
    }

    protected string Name { get; }

    public abstract RamFormFactorBase Clone();
}