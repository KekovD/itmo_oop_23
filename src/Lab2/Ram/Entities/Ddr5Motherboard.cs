using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Entities;

public class Ddr5Motherboard : DdrMotherboardBase
{
    private const string NameConst = "Ddr5";

    public Ddr5Motherboard()
    {
        Name = NameConst;
    }

    public override DdrMotherboardBase Clone() => new Ddr5Motherboard();
}