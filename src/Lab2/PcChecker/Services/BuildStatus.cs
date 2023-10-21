namespace Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;

public enum BuildStatus
{
    None,
    Successfully,
    UnsuitableMotherboardFormFactor,
    UnsuitableMotherboardBiosVersion,
    UnsuitableSocketType,
    CoolingSystemDoesNotSupportDesiredSocket,
    CoolerIsTooHigh,
    WarrantyDisclaimerCoolerHasTooLowTdp,
    UnsuitableDdrType,
    RamFrequencyIsTooLow,
    NotEnoughDdrPortsOnMotherboard,
    DimensionsOfGraphicsCardTooLarge,
    InsufficientNumberOfPciEPorts,
    GraphicsCardHasTooOldVersionOfPciE,
    MotherboardAlreadyHasBuiltInWiFiModule,
    InsufficientNumberOfSataPorts,
    InsufficientNumberOfPortsForSsd,
    XmpInconsistency,
    VideoCoreIsRequired,
    InsufficientPowerSupplyCapacity,
}