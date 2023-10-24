using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IGraphicsCardFactory
{
    public IGraphicsCardFactory RepositoryInstances(IList<object> instances);
    public GraphicsCardBase Crate();

    public IGraphicsCardFactory CustomInstances(
        string name,
        int height,
        int width,
        int videoMemoryNumber,
        PciEVersionBase pciEVersion,
        int chipFrequency,
        int powerConsumption);
}