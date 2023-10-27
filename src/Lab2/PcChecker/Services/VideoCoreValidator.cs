using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public class VideoCoreValidator : IVideoCoreValidator
{
    public IVideoCoreValidator CheckVideoCoreAvailability(CentralProcessorBase processor, GraphicsCardBase? graphicsCard, IList<BuildStatus> result)
    {
        if (processor.IntegratedVideoCore.HaveIntegratedVideoCore() || graphicsCard is not null)
            return this;

        result.Add(BuildStatus.VideoCoreIsRequired);

        return this;
    }
}