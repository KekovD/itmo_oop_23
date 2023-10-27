using Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Entities;

public class RamFormFactor : RamFormFactorBase
{
    public RamFormFactor(string name)
        : base(name)
    {
    }

    public override RamFormFactorBase Clone() => new RamFormFactor((string)Name.Clone());
}