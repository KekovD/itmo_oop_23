using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Entities;

public class PciE2 : PciEVersionBase
{
    private const string NameConst = "PciE2";
    private const int VersionConst = 2;

    public PciE2()
    {
        Name = NameConst;
        Version = VersionConst;
    }

    public override PciEVersionBase Clone() => new PciE2();
}