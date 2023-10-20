using Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Entities;

public class RDimm : RamFormFactorBase
{
    private const string NameConst = "RDimm";

    public RDimm()
    {
        Name = NameConst;
    }

    public override RamFormFactorBase Clone()
        => new RDimm();
}