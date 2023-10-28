using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public class SolidStateDriveValidator : ISolidStateDriveValidator
{
    public ISolidStateDriveValidator CheckPortsSolidStateDrive(SsdBase solidStateDrive, ref MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (solidStateDrive.ConnectionOption.InstallingSsd(ref motherboard))
            return this;

        result.Add(BuildStatus.InsufficientNumberOfPortsForSsd);

        return this;
    }
}