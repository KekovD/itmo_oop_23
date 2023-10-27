using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Entities;

public class WithoutPciE : PciEVersionBase
{
    public WithoutPciE()
    {
    }

    public override PciEVersionBase Clone() => new WithoutPciE();
}