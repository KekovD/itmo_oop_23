using Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Entities;

public class Dimm : RamFormFactorBase
{
    private const string NameConst = "Dimm";

    public Dimm()
    {
        Name = NameConst;
    }

    public override RamFormFactorBase Clone()
        => new Dimm();
}