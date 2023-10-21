using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Entities;

public class Ddr2Motherboard : DdrMotherboardBase
{
    private const string NameConst = "Ddr2";

    public Ddr2Motherboard()
    {
        Name = NameConst;
    }

    public override DdrMotherboardBase Clone() => new Ddr2Motherboard();

    public override bool CompareDdrType(DdrMotherboardBase ddrOther)
    {
        if (ddrOther is Ddr2Motherboard)
            return true;

        return false;
    }
}