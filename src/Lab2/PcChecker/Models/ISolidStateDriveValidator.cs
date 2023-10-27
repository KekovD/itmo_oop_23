using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

public interface ISolidStateDriveValidator
{
    ISolidStateDriveValidator CheckPortsSolidStateDrive(SsdBase solidStateDrive, ref MotherboardBase motherboard, IList<BuildStatus> result);
}