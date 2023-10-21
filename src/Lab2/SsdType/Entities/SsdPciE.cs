using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdType.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.SsdType.Entities;

public class SsdPciE : SsdTypeBase
{
    private const string NameConst = "SsdPciE";

    public SsdPciE()
    {
        Name = NameConst;
    }

    public override SsdTypeBase Clone() => new SsdPciE();

    public override bool InstallingSsd(ref MotherboardBase motherboard)
    {
        if (motherboard.PciENumber > 0)
        {
            const int installing = 1;
            motherboard = motherboard.CloneWithNewPciENumber(motherboard.PciENumber - installing);
            return true;
        }

        return false;
    }
}