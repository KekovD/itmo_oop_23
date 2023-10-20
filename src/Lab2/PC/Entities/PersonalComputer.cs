using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Entities;

public class PersonalComputer
{
    private readonly CaseBase? _pcCase;
    private readonly MotherboardBase? _motherboard;
    private readonly CentralProcessorBase? _centralProcessor;
    private readonly CoolingSystemBase? _coolingSystem;
    private readonly RamBase? _operatingMemory;
    private readonly GraphicsCardBase? _graphicsCard;
    private readonly WiFiModuleBase? _wiFiModule;
    private readonly HddBase? _hardDriver;
    private readonly SsdBase? _solidStateDrive;
    private readonly PowerSupplyBase? _powerSupplyUnit;

    public PersonalComputer(
        CaseBase? pcCase,
        MotherboardBase? motherboard,
        CentralProcessorBase? centralProcessor,
        CoolingSystemBase? coolingSystem,
        RamBase? operatingMemory,
        GraphicsCardBase? graphicsCard,
        WiFiModuleBase? wiFiModule,
        HddBase? hardDriver,
        SsdBase? solidStateDrive,
        PowerSupplyBase? powerSupplyUnit)
    {
        _pcCase = pcCase;
        _motherboard = motherboard;
        _centralProcessor = centralProcessor;
        _coolingSystem = coolingSystem;
        _operatingMemory = operatingMemory;
        _graphicsCard = graphicsCard;
        _wiFiModule = wiFiModule;
        _hardDriver = hardDriver;
        _solidStateDrive = solidStateDrive;
        _powerSupplyUnit = powerSupplyUnit;
    }
}