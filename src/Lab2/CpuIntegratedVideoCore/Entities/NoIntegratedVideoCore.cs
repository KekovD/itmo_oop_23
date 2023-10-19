using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Entities;

public class NoIntegratedVideoCore : IntegratedVideoCoreBase
{
    private const string NameConst = "NoIntegratedVideoCore";

    public NoIntegratedVideoCore()
    {
        Name = NameConst;
    }
}