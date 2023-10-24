using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;

public interface IGraphicsCardValidator
{
    IGraphicsCardValidator CheckDimensionsGraphicsCard(in GraphicsCardBase graphicsCard, in CaseBase pcCase, IList<BuildStatus> result);

    IGraphicsCardValidator CheckPciENumberGraphicsCard(in GraphicsCardBase graphicsCard, ref MotherboardBase motherboard, IList<BuildStatus> result);

    IGraphicsCardValidator CheckPciEVersionGraphicsCard(in GraphicsCardBase graphicsCard, in MotherboardBase motherboard, IList<BuildStatus> result);
}