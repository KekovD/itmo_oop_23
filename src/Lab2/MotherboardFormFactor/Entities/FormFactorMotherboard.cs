using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Entities;

public class FormFactorMotherboard : FormFactorMotherboardBase
{
    public FormFactorMotherboard(string name, int sideFirst, int sideSecond)
    {
        Name = name;
        SideFirst = sideFirst;
        SideSecond = sideSecond;
    }

    public override FormFactorMotherboardBase Clone()
    {
        if (Name is null)
            throw new CloneNullException(nameof(FormFactorMotherboard));

        return new FormFactorMotherboard(
            (string)Name.Clone(),
            SideFirst,
            SideSecond);
    }

    public FormFactorMotherboardBase CloneWithNewName(string name)
        => new FormFactorMotherboard(name, SideFirst, SideSecond);
}