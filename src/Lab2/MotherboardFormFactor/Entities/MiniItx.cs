using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Entities;

public class MiniItx : FormFactorMotherboardBase
{
    private const string NameConst = "MiniItx";
    private const int SideFirstConst = 170;
    private const int SideSecondConst = 170;

    public MiniItx()
    {
        Name = NameConst;
        SideFirst = SideFirstConst;
        SideSecond = SideSecondConst;
    }

    public override FormFactorMotherboardBase Clone() => new MiniItx();
}