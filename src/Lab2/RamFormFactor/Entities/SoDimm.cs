using Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Entities;

public class SoDimm : RamFormFactorBase
{
    private const string NameConst = "SoDimm";

    public SoDimm()
    {
        Name = NameConst;
    }

    public override RamFormFactorBase Clone()
        => new SoDimm();
}