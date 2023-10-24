using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.IntegratedWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IMotherboardFactory : IFactory
{
    public IFactory CustomInstances(
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
        IIntegratedWiFi integratedWiFi);
}