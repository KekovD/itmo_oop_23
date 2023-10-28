using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

public abstract class GraphicsCardBase : IPowerConsumption, IPrototype<GraphicsCardBase>
{
    protected GraphicsCardBase(
        string name,
        int height,
        int width,
        int videoMemoryNumber,
        PciEVersionBase pciEVersion,
        int chipFrequency,
        int powerConsumption)
    {
        Name = name;
        Height = height;
        Width = width;
        VideoMemoryNumber = videoMemoryNumber;
        PciEVersion = pciEVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public int Height { get; private set; }
    public int Width { get; private set; }
    public int VideoMemoryNumber { get; private set; }
    public PciEVersionBase PciEVersion { get; private set; }
    public int ChipFrequency { get; private set; }
    public int PowerConsumption { get; }

    public abstract GraphicsCardBase Clone();
}