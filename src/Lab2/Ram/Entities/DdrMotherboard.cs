using System;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Entities;

public class DdrMotherboard : DdrMotherboardBase
{
    public DdrMotherboard(string name)
    {
        Name = name;
    }

    public override DdrMotherboardBase Clone()
    {
        if (Name is null)
            throw new CloneNullException(nameof(DdrMotherboard));

        return new DdrMotherboard((string)Name.Clone());
    }

    public override bool CompareDdrType(DdrMotherboardBase ddrOther)
    {
        if (ddrOther.Name is null)
            throw new CheckerNullException(nameof(CompareDdrType));

        return ddrOther.Name.Equals(Name, StringComparison.Ordinal);
    }
}