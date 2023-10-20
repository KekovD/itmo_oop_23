using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Entities;

public class WithoutPciE : PciEVersionBase
{
    private const string NameConst = "WithoutPciE";

    public WithoutPciE()
    {
        Name = NameConst;
    }

    public override PciEVersionBase Clone() => new WithoutPciE();
}