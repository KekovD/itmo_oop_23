using System;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios.Entities;

public class BiosPc : BiosBase
{
    public BiosPc(string name, int version)
        : base(version)
    {
        Name = name;
    }

    public override BiosBase Clone()
    {
        if (Name is null)
            throw new CloneNullException(nameof(BiosBase));

        return new BiosPc(
            (string)Name.Clone(),
            Version);
    }

    public BiosBase CloneWithNewName(string name) => new BiosPc(name, Version);

    public override bool CompareBios(BiosBase bios)
    {
        if (bios.Name is null)
            throw new CheckerNullException(nameof(CompareBios));

        if (bios.Name.Equals(Name, StringComparison.Ordinal) && Version >= bios.Version)
            return true;

        return false;
    }
}