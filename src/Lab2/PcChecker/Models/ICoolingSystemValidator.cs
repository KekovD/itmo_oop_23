using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

public interface ICoolingSystemValidator
{
    ICoolingSystemValidator CheckSocketCoolingSystem(CoolingSystemBase coolingSystem, MotherboardBase motherboard, IList<BuildStatus> result);

    ICoolingSystemValidator CheckHeightCoolingSystem(CoolingSystemBase coolingSystem, CaseBase pcCase, IList<BuildStatus> result);

    ICoolingSystemValidator CheckTdpCoolingSystem(CoolingSystemBase coolingSystem, CentralProcessorBase processor, IList<BuildStatus> result);
}