using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

public interface IMotherboardValidator
{
    IMotherboardValidator CheckMotherboardFormFactor(in CaseBase pcCase, in MotherboardBase motherboard, IList<BuildStatus> result);
}