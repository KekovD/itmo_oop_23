using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Entities;

public class Eatx : FormFactorMotherboardBase
{
    private const string NameConst = "Eatx";
    private const int SideFirstConst = 305;
    private const int SideSecondConst = 330;

    public Eatx()
    {
        Name = NameConst;
        SideFirst = SideFirstConst;
        SideSecond = SideSecondConst;
    }

    public override FormFactorMotherboardBase Clone() => new Eatx();
}