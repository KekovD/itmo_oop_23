using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcBuilder.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;
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
    private readonly List<BuildStatus> _buildResult = new List<BuildStatus>();
    private readonly List<BuildStatus> _warrantyDisclaimer = new List<BuildStatus>();

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

        if (_pcCase is null)
            throw new CheckerNullException(nameof(WithMotherboard));

        new MotherboardValidator().CheckMotherboardFormFactor(_pcCase, _motherboard, _buildResult);

        return this;
    }

    public ICoolingSystemBuilder WithCentralProcessor(CentralProcessorBase centralProcessor)
    {
        _centralProcessor = centralProcessor;

        if (_motherboard is null)
            throw new CheckerNullException(nameof(WithCentralProcessor));

        new CentralProcessorValidator()
            .CheckSocket(_centralProcessor, _motherboard, _buildResult)
            .CheckProcessorBios(_centralProcessor, _motherboard, _buildResult);

        return this;
    }

    public IOperatingMemoryBuilder WithCoolingSystem(CoolingSystemBase coolingSystem)
    {
        _coolingSystem = coolingSystem;

        if (_motherboard is null)
            throw new CheckerNullException(nameof(WithCoolingSystem));

        if (_pcCase is null)
            throw new CheckerNullException(nameof(WithCoolingSystem));

        if (_centralProcessor is null)
            throw new CheckerNullException(nameof(WithCoolingSystem));

        new CoolingSystemValidator()
            .CheckSocketCoolingSystem(_coolingSystem, _motherboard, _buildResult)
            .CheckHeightCoolingSystem(_coolingSystem, _pcCase, _buildResult)
            .CheckTdpCoolingSystem(_coolingSystem, _centralProcessor, _warrantyDisclaimer);

        return this;
    }

    public IAdditionalComponentsAndMemoryBuilder WithOperatingMemory(RamBase operatingMemory)
    {
        _operatingMemory = operatingMemory;

        if (_motherboard is null)
            throw new CheckerNullException(nameof(WithOperatingMemory));

        new OperationMemoryValidator()
            .CheckDdrType(_operatingMemory, _motherboard, _buildResult)
            .CheckFrequencyOperationMemory(_operatingMemory, _motherboard, _buildResult)
            .CheckDdrPortsNumber(_operatingMemory, _motherboard, _buildResult)
            .CheckXmp(_operatingMemory, _motherboard, _buildResult);

        return this;
    }

    public IAdditionalComponentsAndMemoryBuilder WithGraphicsCard(GraphicsCardBase graphicsCard)
    {
        _graphicsCard = graphicsCard;

        if (_motherboard is null)
            throw new CheckerNullException(nameof(WithGraphicsCard));

        new GraphicsCardValidator()
            .CheckDimensionsGraphicsCard(
                _graphicsCard,
                _pcCase ?? throw new CheckerNullException(nameof(WithGraphicsCard)),
                _buildResult)
            .CheckPciENumberGraphicsCard(_graphicsCard, ref _motherboard, _buildResult)
            .CheckPciEVersionGraphicsCard(_graphicsCard, _motherboard, _buildResult);

        return this;
    }

    public IAdditionalComponentsAndMemoryBuilder WithWiFiModule(WiFiModuleBase wiFiModule)
    {
        _wiFiModule = wiFiModule;

        if (_motherboard is null)
            throw new CheckerNullException(nameof(WithWiFiModule));

        new WiFiModuleValidator().CheckBuiltInWiFiModule(_motherboard, _buildResult);

        return this;
    }

    public IPowerSupplyUnitBuilder WithHardDriver(HddBase hardDriver)
    {
        _hardDriver = hardDriver;

        if (_motherboard is null)
            throw new CheckerNullException(nameof(WithWiFiModule));

        new HardDriveValidator().CheckSataNumber(ref _motherboard, _buildResult);

        return this;
    }

    public IPowerSupplyUnitBuilder WithSolidStateDrive(SsdBase solidStateDrive)
    {
        _solidStateDrive = solidStateDrive;

        if (_motherboard is null)
            throw new CheckerNullException(nameof(WithSolidStateDrive));

        new SolidStateDriveValidator().CheckPortsSolidStateDrive(_solidStateDrive, ref _motherboard, _buildResult);

        return this;
    }

    public IPersonalComputerBuilder WithPowerSupplyUnit(PowerSupplyBase powerSupply)
    {
        _powerSupplyUnit = powerSupply;

        return this;
    }

    public PersonalComputer Build()
    {
        if (_centralProcessor is null)
            throw new CheckerNullException(nameof(Build));

        new VideoCoreValidator().CheckVideoCoreAvailability(_centralProcessor, _graphicsCard, _buildResult);

        if (_powerSupplyUnit is null)
            throw new CheckerNullException(nameof(Build));

        if (_operatingMemory is null)
            throw new CheckerNullException(nameof(Build));

        new PowerConsumptionValidator().CheckPowerConsumption(
            _powerSupplyUnit,
            _centralProcessor,
            _graphicsCard,
            _solidStateDrive,
            _hardDriver,
            _operatingMemory,
            _wiFiModule,
            _warrantyDisclaimer);

        return new PersonalComputer(
            new ReportWriting().ReportCompilation(_buildResult, _warrantyDisclaimer),
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