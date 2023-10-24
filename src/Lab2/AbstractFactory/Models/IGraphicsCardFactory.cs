using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IGraphicsCardFactory : IFactory
{
    public IFactory CustomInstances(
        string name,
        int height,
        int width,
        int videoMemoryNumber,
        PciEVersionBase pciEVersion,
        int chipFrequency,
        int powerConsumption);
}