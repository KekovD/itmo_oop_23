using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public class MotherboardValidator : IMotherboardValidator
{
    public IMotherboardValidator CheckMotherboardFormFactor(in CaseBase pcCase, in MotherboardBase motherboard, IList<BuildStatus> result)
    {
        foreach (FormFactorMotherboardBase formFactor in pcCase.MotherboardFormFactors)
        {
            if (motherboard.FormFactor.CompareFormFactor(formFactor))
                return this;
        }

        result.Add(BuildStatus.UnsuitableMotherboardFormFactor);

        return this;
    }
}