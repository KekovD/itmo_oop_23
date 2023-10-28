using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;

namespace Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Entities;

public class IntegratedVideoCore : IntegratedVideoCoreBase
{
    public IntegratedVideoCore(string name)
    {
        Name = name;
    }

    public override IntegratedVideoCoreBase Clone()
    {
        if (Name is null)
        {
            throw new CloneNullException(nameof(IntegratedVideoCore));
        }

        return new IntegratedVideoCore((string)Name.Clone());
    }

    public override bool HaveIntegratedVideoCore() => true;
}