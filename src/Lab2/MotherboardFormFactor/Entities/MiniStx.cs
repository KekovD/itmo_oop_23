using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Entities;

public class MiniStx : FormFactorMotherboardBase
{
    private const string NameConst = "MiniStx";
    private const int SideFirstConst = 140;
    private const int SideSecondConst = 140;

    public MiniStx()
    {
        Name = NameConst;
        SideFirst = SideFirstConst;
        SideSecond = SideSecondConst;
    }

    public override FormFactorMotherboardBase Clone() => new MiniStx();

    public override bool CompareFormFactor(FormFactorMotherboardBase formFactor)
    {
        if (formFactor is MiniStx)
            return true;

        return false;
    }
}