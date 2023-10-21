using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Entities;

public class IntelUHDGraphics610 : IntegratedVideoCoreBase
{
    private const string NameConst = "IntelUHDGraphics610";

    public IntelUHDGraphics610()
    {
        Name = NameConst;
    }

    public override IntegratedVideoCoreBase Clone() => new IntelUHDGraphics610();

    public override bool HaveIntegratedVideoCore() => true;
}