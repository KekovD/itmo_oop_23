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

    public string Name { get; }
    public int MemorySize { get; private set; }
    public int CardsNumber { get; private set; }
    public Jedec JedecProfile { get; private set; }
    public XmpJedecBase ExtremeMemoryProfile { get; private set; }
    public RamFormFactorBase RamFormFactor { get; private set; }
    public DdrMotherboardBase DdrType { get; private set; }
    public int PowerConsumption { get; }

    public abstract RamBase Clone();
}