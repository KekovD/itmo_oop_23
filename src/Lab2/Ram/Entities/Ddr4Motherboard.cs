using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Entities;

public class Ddr4Motherboard : DdrMotherboardBase
{
    private const string NameConst = "Ddr4";

    public Ddr4Motherboard()
    {
        Name = NameConst;
    }

    public override DdrMotherboardBase Clone() => new Ddr4Motherboard();
}