using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios.Entities;

public class Bios : BiosBase
{
    public Bios(string name, int version)
        : base(version)
    {
        Name = name;
    }
}