using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Entities;

public class Atx : FormFactorMotherboardBase
{
    private const string NameConst = "Atx";
    private const int SideFirstConst = 305;
    private const int SideSecondConst = 244;

    public Atx()
    {
        Name = NameConst;
        SideFirst = SideFirstConst;
        SideSecond = SideSecondConst;
    }

    public override FormFactorMotherboardBase Clone() => new Atx();

    public override bool CompareFormFactor(FormFactorMotherboardBase formFactor)
    {
        if (formFactor is Atx)
            return true;

        return false;
    }
}