using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Models;

public abstract class IntegratedVideoCoreBase : IPrototype<IntegratedVideoCoreBase>
{
    public string? Name { get; protected set; }

    public IntegratedVideoCoreBase Clone() =>
        new IntegratedVideoCore(this.Name ?? throw new CloneNullException(nameof(IntegratedVideoCoreBase)));

    public IntegratedVideoCoreBase CloneWithNewName(string name)
    {
        IntegratedVideoCoreBase clone = Clone();
        clone.Name = name;

        return clone;
    }
}