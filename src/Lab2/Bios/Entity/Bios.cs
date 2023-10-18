using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios.Entity;

public class Bios : BiosBase
{
    public Bios(string name, int version)
        : base(version)
    {
        Name = name;
    }
}