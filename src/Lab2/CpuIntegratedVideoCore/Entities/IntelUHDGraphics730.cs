using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Entities;

public class IntelUHDGraphics730 : IntegratedVideoCoreBase
{
    private const string NameConst = "IntelUHDGraphics730";

    public IntelUHDGraphics730()
    {
        Name = NameConst;
    }

    public override IntegratedVideoCoreBase Clone() => new IntelUHDGraphics730();
}