using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.CasePc.Entities;

public class PcCase : CaseBase
{
    public PcCase(
        string name,
        int maximumLength,
        int maximumWidth,
        IList<FormFactorMotherboardBase> motherboardFormFactors,
        int length,
        int width,
        int height)
        : base(name, maximumLength, maximumWidth, motherboardFormFactors, length, width, height)
    {
    }

    public override CaseBase Clone()
    {
        var clonedMotherboardFormFactors = MotherboardFormFactors
            .Select(factor => factor
                .Clone())
            .ToList();

        return new PcCase(
            (string)Name.Clone(),
            MaximumLength,
            MaximumWidth,
            clonedMotherboardFormFactors,
            Length,
            Width,
            Height);
    }
}