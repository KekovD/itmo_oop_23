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
    private BuildChecker _checker = new BuildChecker();
    private List<BuildStatus> _buildResult = new List<BuildStatus>();
    private List<BuildStatus> _warrantyDisclaimer = new List<BuildStatus>();

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

        _checker.CheckMotherboardFormFactor(_pcCase, _motherboard, _buildResult);

        return this;
    }

    public ICoolingSystemBuilder WithCentralProcessor(CentralProcessorBase centralProcessor)
    {
        _centralProcessor = centralProcessor;

        if (_motherboard is null)
            throw new CheckerNullException(nameof(WithCentralProcessor));

        _checker.CheckSocket(_centralProcessor, _motherboard, _buildResult);
        _checker.CheckProcessorBios(_centralProcessor, _motherboard, _buildResult);

        return this;
    }

    public IOperatingMemoryBuilder WithCoolingSystem(CoolingSystemBase coolingSystem)
    {
        _coolingSystem = coolingSystem;

        if (_motherboard is null)
            throw new CheckerNullException(nameof(WithCoolingSystem));

        _checker.CheckSocketCoolingSystem(_coolingSystem, _motherboard, _buildResult);

        if (_pcCase is null)
            throw new CheckerNullException(nameof(WithCoolingSystem));

        _checker.CheckHeightCoolingSystem(_coolingSystem, _pcCase, _buildResult);

        if (_centralProcessor is null)
            throw new CheckerNullException(nameof(WithCoolingSystem));

        _checker.CheckTdpCoolingSystem(_coolingSystem, _centralProcessor, _warrantyDisclaimer);

        return this;
    }

    public IAdditionalComponentsAndMemoryBuilder WithOperatingMemory(RamBase operatingMemory)
    {
        _operatingMemory = operatingMemory;

        if (_motherboard is null)
            throw new CheckerNullException(nameof(WithOperatingMemory));

        _checker.CheckDdrType(_operatingMemory, _motherboard, _buildResult);
        _checker.CheckFrequencyOperationMemory(_operatingMemory, _motherboard, _buildResult);
        _checker.CheckDdrPortsNumber(_operatingMemory, _motherboard, _buildResult);
        _checker.CheckXmp(_operatingMemory, _motherboard, _buildResult);

        return this;
    }

    public IAdditionalComponentsAndMemoryBuilder WithGraphicsCard(GraphicsCardBase graphicsCard)
    {
        _graphicsCard = graphicsCard;

        if (_motherboard is null)
            throw new CheckerNullException(nameof(WithGraphicsCard));

        _checker.CheckPciENumberGraphicsCard(_graphicsCard, ref _motherboard, _buildResult);
        _checker.CheckPciEVersionGraphicsCard(_graphicsCard, _motherboard, _buildResult);

        return this;
    }

    public IAdditionalComponentsAndMemoryBuilder WithWiFiModule(WiFiModuleBase wiFiModule)
    {
        _wiFiModule = wiFiModule;

        if (_motherboard is null)
            throw new CheckerNullException(nameof(WithWiFiModule));

        _checker.CheckBuiltInWiFiModule(_motherboard, _buildResult);

        return this;
    }

    public IPowerSupplyUnitBuilder WithHardDriver(HddBase hardDriver)
    {
        _hardDriver = hardDriver;

        if (_motherboard is null)
            throw new CheckerNullException(nameof(WithWiFiModule));

        _checker.CheckSataNumber(ref _motherboard, _buildResult);

        return this;
    }

    public IPowerSupplyUnitBuilder WithSolidStateDrive(SsdBase solidStateDrive)
    {
        _solidStateDrive = solidStateDrive;

        if (_motherboard is null)
            throw new CheckerNullException(nameof(WithSolidStateDrive));

        _checker.CheckPortsSolidStateDrive(_solidStateDrive, ref _motherboard, _buildResult);

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

        _checker.CheckVideoCoreAvailability(_centralProcessor, _graphicsCard, _buildResult);

        if (_powerSupplyUnit is null)
            throw new CheckerNullException(nameof(Build));

        if (_operatingMemory is null)
            throw new CheckerNullException(nameof(Build));

        _checker.CheckPowerConsumption(
            _powerSupplyUnit,
            _centralProcessor,
            _graphicsCard,
            _solidStateDrive,
            _hardDriver,
            _operatingMemory,
            _wiFiModule,
            _warrantyDisclaimer);

        return new PersonalComputer(
            _checker.ReportWriting(_buildResult, _warrantyDisclaimer),
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