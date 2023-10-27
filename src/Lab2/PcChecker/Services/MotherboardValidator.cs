using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public class MotherboardValidator : IMotherboardValidator
{
    public IMotherboardValidator CheckMotherboardFormFactor(CaseBase pcCase, MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (pcCase.MotherboardFormFactors.Any(formFactor => motherboard.FormFactor.CompareFormFactor(formFactor)))
        {
            return this;
        }

        result.Add(BuildStatus.UnsuitableMotherboardFormFactor);

        return this;
    }
}