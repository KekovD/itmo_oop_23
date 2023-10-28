using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public class GraphicsCardValidator : IGraphicsCardValidator
{
    public IGraphicsCardValidator CheckDimensionsGraphicsCard(GraphicsCardBase graphicsCard, CaseBase pcCase, IList<BuildStatus> result)
    {
        if (graphicsCard.Height <= pcCase.MaximumWidth && graphicsCard.Width <= pcCase.MaximumLength)
            return this;

        result.Add(BuildStatus.DimensionsOfGraphicsCardTooLarge);

        return this;
    }

    public IGraphicsCardValidator CheckPciENumberGraphicsCard(GraphicsCardBase graphicsCard, ref MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (motherboard.PciENumber > 0)
        {
            const int graphicsCardInstallation = 1;
            motherboard = motherboard.CloneWithNewPciENumber(motherboard.PciENumber - graphicsCardInstallation);
            return this;
        }

        result.Add(BuildStatus.InsufficientNumberOfPciEPorts);

        return this;
    }

    public IGraphicsCardValidator CheckPciEVersionGraphicsCard(GraphicsCardBase graphicsCard, MotherboardBase motherboard, IList<BuildStatus> result)
    {
        if (graphicsCard.PciEVersion.Version >= motherboard.PciEVersion.Version)
            return this;

        result.Add(BuildStatus.GraphicsCardHasTooOldVersionOfPciE);

        return this;
    }
}