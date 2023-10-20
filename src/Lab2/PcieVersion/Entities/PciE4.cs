using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Entities;

public class PciE4 : PciEVersionBase
{
    private const string NameConst = "PciE4";
    private const int VersionConst = 4;

    public PciE4()
    {
        Name = NameConst;
        Version = VersionConst;
    }

    public override PciEVersionBase Clone() => new PciE4();
}