using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios.Entities;

public class Bios : BiosBase
{
    public Bios(string name, int version)
        : base(version)
    {
        Name = name;
    }

    public override BiosBase Clone() =>
        new Bios(
            Name ?? throw new CloneNullException(nameof(BiosBase)),
            Version);
}