using Itmo.ObjectOrientedProgramming.Lab2.SsdType.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.SsdType.Entities;

public class SsdPciE : SsdTypeBase
{
    private const string NameConst = "SsdPciE";

    public SsdPciE()
    {
        Name = NameConst;
    }

    public override SsdTypeBase Clone() => new SsdPciE();
}