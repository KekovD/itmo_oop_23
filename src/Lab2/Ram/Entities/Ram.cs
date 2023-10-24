using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Entities;

public class Ram : RamBase
{
    public Ram(
        string name,
        int memorySize,
        int cardsNumber,
        Jedec jedecProfile,
        XmpJedecBase extremeMemoryProfile,
        RamFormFactorBase ramFormFactor,
        DdrMotherboardBase ddrType,
        int powerConsumption)
        : base(
            name,
            memorySize,
            cardsNumber,
            jedecProfile,
            extremeMemoryProfile,
            ramFormFactor,
            ddrType,
            powerConsumption)
    {
    }

    public override RamBase Clone()
    {
        return new Ram(
            (string)Name.Clone(),
            MemorySize,
            CardsNumber,
            (Jedec)JedecProfile.Clone(),
            ExtremeMemoryProfile.Clone(),
            RamFormFactor.Clone(),
            DdrType.Clone(),
            PowerConsumption);
    }
}