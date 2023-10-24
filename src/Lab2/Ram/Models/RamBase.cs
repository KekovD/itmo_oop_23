using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

public abstract class RamBase : IPowerConsumption, IPrototype<RamBase>
{
    protected RamBase(
        string name,
        int memorySize,
        int cardsNumber,
        Jedec jedecProfile,
        XmpJedecBase extremeMemoryProfile,
        RamFormFactorBase ramFormFactor,
        DdrMotherboardBase ddrType,
        int powerConsumption)
    {
        Name = name;
        MemorySize = memorySize;
        CardsNumber = cardsNumber;
        JedecProfile = jedecProfile;
        ExtremeMemoryProfile = extremeMemoryProfile;
        RamFormFactor = ramFormFactor;
        DdrType = ddrType;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; private set; }
    public int MemorySize { get; private set; }
    public int CardsNumber { get; private set; }
    public Jedec JedecProfile { get; private set; }
    public XmpJedecBase ExtremeMemoryProfile { get; private set; }
    public RamFormFactorBase RamFormFactor { get; private set; }
    public DdrMotherboardBase DdrType { get; private set; }
    public int PowerConsumption { get; private set; }

    public abstract RamBase Clone();

    public RamBase CloneWithNewName(string name)
    {
        RamBase clone = Clone();
        clone.Name = name;

        return clone;
    }

    public RamBase CloneWithNewMemorySize(int memorySize)
    {
        RamBase clone = Clone();
        clone.MemorySize = memorySize;

        return clone;
    }

    public RamBase CloneWithNewCardsNumber(int cardsNumber)
    {
        RamBase clone = Clone();
        clone.CardsNumber = cardsNumber;

        return clone;
    }

    public RamBase CloneWithNewJedecProfile(Jedec jedecProfile)
    {
        RamBase clone = Clone();
        clone.JedecProfile = jedecProfile;

        return clone;
    }

    public RamBase CloneWithNewExtremeMemoryProfile(XmpJedecBase extremeMemoryProfile)
    {
        RamBase clone = Clone();
        clone.ExtremeMemoryProfile = extremeMemoryProfile;

        return clone;
    }

    public RamBase CloneWithNewRamFormFactor(RamFormFactorBase ramFormFactor)
    {
        RamBase clone = Clone();
        clone.RamFormFactor = ramFormFactor;

        return clone;
    }

    public RamBase CloneWithNewDdrType(DdrMotherboardBase ddrType)
    {
        RamBase clone = Clone();
        clone.DdrType = ddrType;

        return clone;
    }

    public RamBase CloneWithNewPowerConsumption(int powerConsumption)
    {
        RamBase clone = Clone();
        clone.PowerConsumption = powerConsumption;

        return clone;
    }
}