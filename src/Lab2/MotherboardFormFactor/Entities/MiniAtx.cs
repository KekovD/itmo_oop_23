using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Entities;

public class MiniAtx : FormFactorMotherboardBase
{
    private const string NameConst = "MiniAtx";
    private const int SideFirstConst = 284;
    private const int SideSecondConst = 208;

    public MiniAtx()
    {
        Name = NameConst;
        SideFirst = SideFirstConst;
        SideSecond = SideSecondConst;
    }

    public override FormFactorMotherboardBase Clone() => new MiniAtx();
}