using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

public interface IVideoCoreValidator
{
    IVideoCoreValidator CheckVideoCoreAvailability(in CentralProcessorBase processor, GraphicsCardBase? graphicsCard, IList<BuildStatus> result);
}