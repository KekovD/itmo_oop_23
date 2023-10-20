using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Entities;

public class PciE3 : PciEVersionBase
{
    private const string NameConst = "PciE3";
    private const int VersionConst = 3;

    public PciE3()
    {
        Name = NameConst;
        Version = VersionConst;
    }

    public override PciEVersionBase Clone() => new PciE3();
}