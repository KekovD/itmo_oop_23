using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;

public class RamFactory : IRamFactory
{
    public IPart CreateByName(string name) =>
        new Ram.Entities.Ram(new RamRepository().GetByName(name));

    public IPart CreateCustom(
        string name,
        int memorySize,
        int cardsNumber,
        Jedec jedecProfile,
        XmpJedecBase extremeMemoryProfile,
        RamFormFactorBase ramFormFactor,
        DdrMotherboardBase ddrType,
        int powerConsumption)
    {
        return new Ram.Entities.Ram(
            name,
            memorySize,
            cardsNumber,
            jedecProfile,
            extremeMemoryProfile,
            ramFormFactor,
            ddrType,
            powerConsumption);
    }
}