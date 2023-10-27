using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.IntegratedWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;

public abstract class MotherboardBase : IPart, IPrototype<MotherboardBase>
{
    protected MotherboardBase(
        string name,
        SocketBase socket,
        int pciENumber,
        int sataNumber,
        int memoryFrequencies,
        XmpJedecBase extremeMemoryProfiles,
        DdrMotherboardBase ddrMotherboard,
        int ramTablesNumber,
        FormFactorMotherboardBase formFactor,
        BiosBase bios,
        PciEVersionBase pciEVersion,
        IIntegratedWiFi integratedWiFi)
    {
        Name = name;
        Socket = socket;
        PciENumber = pciENumber;
        SataNumber = sataNumber;
        MemoryFrequencies = memoryFrequencies;
        ExtremeMemoryProfiles = extremeMemoryProfiles;
        DdrMotherboard = ddrMotherboard;
        RamTablesNumber = ramTablesNumber;
        FormFactor = formFactor;
        Bios = bios;
        PciEVersion = pciEVersion;
        IntegratedWiFi = integratedWiFi;
    }

    public string Name { get; private set; }
    public SocketBase Socket { get; private set; }
    public int PciENumber { get; private set; }
    public int SataNumber { get; private set; }
    public int MemoryFrequencies { get; private set; }
    public XmpJedecBase ExtremeMemoryProfiles { get; private set; }
    public DdrMotherboardBase DdrMotherboard { get; private set; }
    public int RamTablesNumber { get; private set; }
    public FormFactorMotherboardBase FormFactor { get; private set; }
    public BiosBase Bios { get; private set; }
    public PciEVersionBase PciEVersion { get; private set; }
    public IIntegratedWiFi IntegratedWiFi { get; private set; }

    public abstract MotherboardBase Clone();

    public MotherboardBase CloneWithNewPciENumber(int pciENumber)
    {
        MotherboardBase clone = Clone();
        clone.PciENumber = pciENumber;

        return clone;
    }

    public MotherboardBase CloneWithNewSataNumber(int sataNumber)
    {
        MotherboardBase clone = Clone();
        clone.SataNumber = sataNumber;

        return clone;
    }
}