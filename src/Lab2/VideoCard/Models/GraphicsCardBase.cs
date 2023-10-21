using System.Collections.Generic;
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

    protected GraphicsCardBase(IList<object> characteristics)
    {
        Name = (string)characteristics[0];
        Height = (int)characteristics[1];
        Width = (int)characteristics[2];
        VideoMemoryNumber = (int)characteristics[3];
        PciEVersion = (PciEVersionBase)characteristics[4];
        ChipFrequency = (int)characteristics[5];
        PowerConsumption = (int)characteristics[6];
    }

    public string Name { get; private set; }
    public int Height { get; private set; }
    public int Width { get; private set; }
    public int VideoMemoryNumber { get; private set; }
    public PciEVersionBase PciEVersion { get; private set; }
    public int ChipFrequency { get; private set; }
    public int PowerConsumption { get; private set; }

    public abstract GraphicsCardBase Clone();

    public GraphicsCardBase CloneWithNewName(string name)
    {
        GraphicsCardBase clone = Clone();
        clone.Name = name;

        return clone;
    }

    public GraphicsCardBase CloneWithNewDimensions(int height, int width)
    {
        GraphicsCardBase clone = Clone();
        clone.Height = height;
        clone.Width = width;

        return clone;
    }

    public GraphicsCardBase CloneWithNewVideoMemoryNumber(int videoMemoryNumber)
    {
        GraphicsCardBase clone = Clone();
        clone.VideoMemoryNumber = videoMemoryNumber;

        return clone;
    }

    public GraphicsCardBase CloneWithNewPciEVersion(PciEVersionBase pciEVersion)
    {
        GraphicsCardBase clone = Clone();
        clone.PciEVersion = pciEVersion;

        return clone;
    }

    public GraphicsCardBase CloneWithNewChipFrequency(int chipFrequency)
    {
        GraphicsCardBase clone = Clone();
        clone.ChipFrequency = chipFrequency;

        return clone;
    }

    public GraphicsCardBase CloneWithNewPowerConsumption(int powerConsumption)
    {
        GraphicsCardBase clone = Clone();
        clone.PowerConsumption = powerConsumption;

        return clone;
    }
}