using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.IntegratedWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Entities;

public class MotherboardFactory : IMotherboardFactory
{
    public IPart CreateByName(string name) =>
        new Motherboard(new MotherboardRepository().GetByName(name));

    public IPart CreateCustom(
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
        return new Motherboard(
            name,
            socket,
            pciENumber,
            sataNumber,
            memoryFrequencies,
            extremeMemoryProfiles,
            ddrMotherboard,
            ramTablesNumber,
            formFactor,
            bios,
            pciEVersion,
            integratedWiFi);
    }
}