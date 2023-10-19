using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Entities;

public class DdrMotherboard : DdrMotherboardBase
{
    public DdrMotherboard(string name)
    {
        Name = name;
    }

    public override DdrMotherboardBase Clone() =>
        new DdrMotherboard(Name ?? throw new CloneNullException(nameof(DdrMotherboard)));
}