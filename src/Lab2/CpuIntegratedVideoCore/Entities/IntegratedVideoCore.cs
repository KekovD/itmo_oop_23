using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;

namespace Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Entities;

public class IntegratedVideoCore : IntegratedVideoCoreBase
{
    public IntegratedVideoCore(string name)
    {
        Name = name;
    }

    public override IntegratedVideoCoreBase Clone() =>
        new IntegratedVideoCore(Name ?? throw new CloneNullException(nameof(IntegratedVideoCore)));
}