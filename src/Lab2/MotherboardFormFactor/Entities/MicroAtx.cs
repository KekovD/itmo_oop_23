using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Entities;

public class MicroAtx : FormFactorMotherboardBase
{
    private const string NameConst = "MicroAtx";
    private const int SideFirstConst = 244;
    private const int SideSecondConst = 244;

    public MicroAtx()
    {
        Name = NameConst;
        SideFirst = SideFirstConst;
        SideSecond = SideSecondConst;
    }

    public override FormFactorMotherboardBase Clone() => new MicroAtx();
}