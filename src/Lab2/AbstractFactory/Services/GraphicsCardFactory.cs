using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class GraphicsCardFactory : IGraphicsCardFactory
{
    public IPart CreateByName(string name) =>
        new GraphicsCard(new GraphicsCardRepository().GetByName(name));

    public IPart CreateCustom(
        string name,
        int height,
        int width,
        int videoMemoryNumber,
        PciEVersionBase pciEVersion,
        int chipFrequency,
        int powerConsumption)
    {
        return new GraphicsCard(name, height, width, videoMemoryNumber, pciEVersion, chipFrequency, powerConsumption);
    }
}