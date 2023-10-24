using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IRamFactory : IFactory
{
    public IFactory CustomInstances(
        string name,
        int memorySize,
        int cardsNumber,
        Jedec jedecProfile,
        XmpJedecBase extremeMemoryProfile,
        RamFormFactorBase ramFormFactor,
        DdrMotherboardBase ddrType,
        int powerConsumption);
}