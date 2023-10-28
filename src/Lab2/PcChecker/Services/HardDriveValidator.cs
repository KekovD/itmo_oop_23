using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public class HardDriveValidator : IHardDriveValidator
{
    public IHardDriveValidator CheckSataNumber(ref MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (motherboard.SataNumber > 0)
        {
            const int installation = 1;
            motherboard = motherboard.CloneWithNewSataNumber(motherboard.SataNumber - installation);
            return this;
        }

        result.Add(BuildStatus.InsufficientNumberOfSataPorts);

        return this;
    }
}