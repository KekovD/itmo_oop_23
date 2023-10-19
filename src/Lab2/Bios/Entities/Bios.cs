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

    public override BiosBase Clone()
    {
        if (Name is null)
            throw new CloneNullException(nameof(BiosBase));

        return new Bios(
            (string)Name.Clone(),
            Version);
    }

    public BiosBase CloneWithNewName(string name) => new Bios(name, Version);
}