using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

public interface ICentralProcessorValidator
{
    ICentralProcessorValidator CheckSocket(CentralProcessorBase processor, MotherboardBase motherboard, IList<BuildStatus> result);
    ICentralProcessorValidator CheckProcessorBios(CentralProcessorBase processor, MotherboardBase motherboard, IList<BuildStatus> result);
}