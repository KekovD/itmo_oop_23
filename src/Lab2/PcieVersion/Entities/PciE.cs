using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Entities;

public class PciE : PciEVersionBase
{
    public PciE(int version)
    {
        Version = version;
    }

    public override PciEVersionBase Clone() => new PciE(Version);
}