using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcBuilder.Models;

public interface IAdditionalComponentsAndMemoryBuilder
{
    IAdditionalComponentsAndMemoryBuilder WithGraphicsCard(GraphicsCardBase graphicsCard);

    IAdditionalComponentsAndMemoryBuilder WithWiFiModule(WiFiModuleBase wiFiModule);

    IPowerSupplyUnitBuilder WithHardDriver(HddBase hardDriver);

    IPowerSupplyUnitBuilder WithSolidStateDrive(SsdBase solidStateDrive);
}