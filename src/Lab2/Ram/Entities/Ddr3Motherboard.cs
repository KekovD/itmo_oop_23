using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Entities;

public class Ddr3Motherboard : DdrMotherboardBase
{
    private const string NameConst = "Ddr3";

    public Ddr3Motherboard()
    {
        Name = NameConst;
    }

    public override DdrMotherboardBase Clone() => new Ddr3Motherboard();
}