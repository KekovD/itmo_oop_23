using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios.Entities;

public class Intel64 : BiosBase
{
    private const string Intel64Name = "Intel64";

    public Intel64(int version)
        : base(version)
    {
        Name = Intel64Name;
    }

    public override BiosBase Clone() => new Intel64(Version);

    public override bool CompareBios(BiosBase bios)
    {
        if (bios is Intel64 && Version >= bios.Version)
            return true;

        return false;
    }
}