using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Entities;

public class WithoutIntegratedVideoCore : IntegratedVideoCoreBase
{
    private const string NameConst = "NoIntegratedVideoCore";

    public WithoutIntegratedVideoCore()
    {
        Name = NameConst;
    }

    public override IntegratedVideoCoreBase Clone() => new WithoutIntegratedVideoCore();
}