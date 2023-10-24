using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Entities;

public class GraphicsCard : GraphicsCardBase
{
    public GraphicsCard(
        string name,
        int height,
        int width,
        int videoMemoryNumber,
        PciEVersionBase pciEVersion,
        int chipFrequency,
        int powerConsumption)
        : base(name, height, width, videoMemoryNumber, pciEVersion, chipFrequency, powerConsumption)
    {
    }

    public override GraphicsCardBase Clone()
    {
        return new GraphicsCard(
            (string)Name.Clone(),
            Height,
            Width,
            VideoMemoryNumber,
            PciEVersion.Clone(),
            ChipFrequency,
            PowerConsumption);
    }
}