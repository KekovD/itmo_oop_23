using System;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Entities;

public class FormFactorMotherboard : FormFactorMotherboardBase
{
    public FormFactorMotherboard(string name)
        : base(name)
    {
    }

    public override FormFactorMotherboardBase Clone() => new FormFactorMotherboard((string)Name.Clone());

    public override bool CompareFormFactor(FormFactorMotherboardBase formFactor)
    {
        return formFactor.Name.Equals(Name, StringComparison.Ordinal);
    }
}