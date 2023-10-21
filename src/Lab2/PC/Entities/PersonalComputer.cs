using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Entities;

public class PersonalComputer : IPrototype<PersonalComputer>
{
    private IList<BuildStatus> _message;
    private CaseBase? _pcCase;
    private MotherboardBase? _motherboard;
    private CentralProcessorBase? _centralProcessor;
    private CoolingSystemBase? _coolingSystem;
    private RamBase? _operatingMemory;
    private GraphicsCardBase? _graphicsCard;
    private WiFiModuleBase? _wiFiModule;
    private HddBase? _hardDriver;
    private SsdBase? _solidStateDrive;
    private PowerSupplyBase? _powerSupplyUnit;

    public PersonalComputer(
        IList<BuildStatus> message,
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
        _message = message;
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

    public PersonalComputer Clone()
    {
        return new PersonalComputer(
            new List<BuildStatus>(),
            _pcCase?.Clone(),
            _motherboard?.Clone(),
            _centralProcessor?.Clone(),
            _coolingSystem?.Clone(),
            _operatingMemory?.Clone(),
            _graphicsCard?.Clone(),
            _wiFiModule?.Clone(),
            _hardDriver?.Clone(),
            _solidStateDrive?.Clone(),
            _powerSupplyUnit?.Clone());
    }

    public PersonalComputer CloneWithNewCase(CaseBase pcCase)
    {
        PersonalComputer clone = Clone();
        clone._pcCase = pcCase;

        return clone;
    }

    public PersonalComputer CloneWithNewMotherboard(MotherboardBase motherboard)
    {
        PersonalComputer clone = Clone();
        clone._motherboard = motherboard;

        return clone;
    }

    public PersonalComputer CloneWithNewCentralProcessor(CentralProcessorBase centralProcessor)
    {
        PersonalComputer clone = Clone();
        clone._centralProcessor = centralProcessor;

        return clone;
    }

    public PersonalComputer CloneWithNewCoolingSystem(CoolingSystemBase coolingSystem)
    {
        PersonalComputer clone = Clone();
        clone._coolingSystem = coolingSystem;

        return clone;
    }

    public PersonalComputer CloneWithNewOperatingMemory(RamBase operatingMemory)
    {
        PersonalComputer clone = Clone();
        clone._operatingMemory = operatingMemory;

        return clone;
    }

    public PersonalComputer CloneWithNewGraphicsCard(GraphicsCardBase graphicsCard)
    {
        PersonalComputer clone = Clone();
        clone._graphicsCard = graphicsCard;

        return clone;
    }

    public PersonalComputer CloneWithNewWiFiModule(WiFiModuleBase wiFiModule)
    {
        PersonalComputer clone = Clone();
        clone._wiFiModule = wiFiModule;

        return clone;
    }

    public PersonalComputer CloneWithNewHardDriver(HddBase hardDriver)
    {
        PersonalComputer clone = Clone();
        clone._hardDriver = hardDriver;

        return clone;
    }

    public PersonalComputer CloneWithNewSolidStateDrive(SsdBase solidStateDrive)
    {
        PersonalComputer clone = Clone();
        clone._solidStateDrive = solidStateDrive;

        return clone;
    }

    public PersonalComputer CloneWithNewPowerSupplyUnit(PowerSupplyBase powerSupplyUnit)
    {
        PersonalComputer clone = Clone();
        clone._powerSupplyUnit = powerSupplyUnit;

        return clone;
    }
}