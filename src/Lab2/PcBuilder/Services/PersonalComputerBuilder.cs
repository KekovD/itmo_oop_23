using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcBuilder.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcBuilder.Services;

public class PersonalComputerBuilder : IStartBuilding, ICaseBuilder, IMotherboardBuilder, IСentralProcessorBuilder,
    ICoolingSystemBuilder, IOperatingMemoryBuilder, IAdditionalComponentsAndMemoryBuilder, IPowerSupplyUnitBuilder,
    IPersonalComputerBuilder
{
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

    public ICaseBuilder Builder() => new PersonalComputerBuilder();

    public IMotherboardBuilder WithCase(CaseBase caseBase)
    {
        _pcCase = caseBase;
        return this;
    }

    public IСentralProcessorBuilder WithMotherboard(MotherboardBase motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public ICoolingSystemBuilder WithСentralProcessor(CentralProcessorBase centralProcessor)
    {
        _centralProcessor = centralProcessor;
        return this;
    }

    public IOperatingMemoryBuilder WithCoolingSystem(CoolingSystemBase coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public IAdditionalComponentsAndMemoryBuilder WithOperatingMemory(RamBase operatingMemory)
    {
        _operatingMemory = operatingMemory;
        return this;
    }

    public IAdditionalComponentsAndMemoryBuilder WithGraphicsCard(GraphicsCardBase graphicsCard)
    {
        _graphicsCard = graphicsCard;
        return this;
    }

    public IAdditionalComponentsAndMemoryBuilder WithWiFiModule(WiFiModuleBase wiFiModule)
    {
        _wiFiModule = wiFiModule;
        return this;
    }

    public IPowerSupplyUnitBuilder WithHardDriver(HddBase hardDriver)
    {
        _hardDriver = hardDriver;
        return this;
    }

    public IPowerSupplyUnitBuilder WithSolidStateDrive(SsdBase solidStateDrive)
    {
        _solidStateDrive = solidStateDrive;
        return this;
    }

    public IPersonalComputerBuilder WithPowerSupplyUnit(PowerSupplyBase powerSupply)
    {
        _powerSupplyUnit = powerSupply;
        return this;
    }

    public PersonalComputer Build()
    {
        return new PersonalComputer(
            _pcCase,
            _motherboard,
            _centralProcessor,
            _coolingSystem,
            _operatingMemory,
            _graphicsCard,
            _wiFiModule,
            _hardDriver,
            _solidStateDrive,
            _powerSupplyUnit);
    }
}