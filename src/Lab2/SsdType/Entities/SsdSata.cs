using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdType.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.SsdType.Entities;

public class SsdSata : SsdTypeBase
{
    private const string NameConst = "SsdSata";

    public SsdSata()
    {
        Name = NameConst;
    }

    public override SsdTypeBase Clone() => new SsdSata();

    public override bool InstallingSsd(ref MotherboardBase motherboard)
    {
        if (motherboard.SataNumber > 0)
        {
            const int installing = 1;
            motherboard = motherboard.CloneWithNewSataNumber(motherboard.SataNumber - installing);
            return true;
        }

        return false;
    }
}