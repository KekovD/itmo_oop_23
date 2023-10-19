using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Entities;

public class Ddr1Motherboard : DdrMotherboardBase
{
    private const string NameConst = "Ddr";

    public Ddr1Motherboard()
    {
        Name = NameConst;
    }

    public override DdrMotherboardBase Clone() => new Ddr1Motherboard();
}