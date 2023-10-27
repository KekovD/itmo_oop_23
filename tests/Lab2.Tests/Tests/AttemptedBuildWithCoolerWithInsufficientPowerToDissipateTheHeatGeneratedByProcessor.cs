using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcBuilder.Services;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public class AttemptedBuildWithCoolerWithInsufficientPowerToDissipateTheHeatGeneratedByProcessor
{
    public static IEnumerable<object[]> GetParts
    {
        get
        {
            yield return new object[]
            {
                new List<string>
                {
                    "DeepcoolMatrexx30",
                    "GigabyteB560MH",
                    "IntelCorei511400",
                    "DeepcoolGammaxx300",
                    "DEXP8GD4UD32",
                    "PalitGeForceRTX3050Dual",
                    "CrucialBX500",
                    "AeroCoolECO600W",
                },
            };
        }
    }

    private static bool CheckBuildingResults(PersonalComputer builder)
    {
        return builder.Message is [BuildStatus.Successfully, BuildStatus.WarrantyDisclaimerCoolerHasTooLowTdp];
    }

    [Theory]
    [MemberData(nameof(GetParts), MemberType = typeof(AttemptedBuildWithCoolerWithInsufficientPowerToDissipateTheHeatGeneratedByProcessor))]
    private void ConditionCheck(IList<string> parts)
    {
        new TestRepositories().AddObjects();
        var repository = new Repository();

        IList<object> casePcInstance = repository.Find(parts[0]);
        IList<object> motherboardInstance = repository.Find(parts[1]);
        IList<object> centralProcessorInstance = repository.Find(parts[2]);
        IList<object> coolingSystemInstance = repository.Find(parts[3]);
        IList<object> ramInstance = repository.Find(parts[4]);
        IList<object> graphicsInstance = repository.Find(parts[5]);
        IList<object> ssdInstance = repository.Find(parts[6]);
        IList<object> powerSupplyInstance = repository.Find(parts[7]);

        CaseBase casePc = new PcCaseFactory().RepositoryInstances(casePcInstance).Crate();
        MotherboardBase motherboard = new MotherboardFactory().RepositoryInstances(motherboardInstance).Crate();
        CentralProcessorBase centralProcessor =
            new CentralProcessorFactory().RepositoryInstances(centralProcessorInstance).Crate();
        CoolingSystemBase coolingSystem = new CoolingSystemFactory().RepositoryInstances(coolingSystemInstance).Crate();
        RamBase ram = new RamFactory().RepositoryInstances(ramInstance).Crate();
        GraphicsCardBase graphicsCard = new GraphicsCardFactory().RepositoryInstances(graphicsInstance).Crate();
        SsdBase ssd = new SsdFactory().RepositoryInstances(ssdInstance).Crate();
        PowerSupplyBase powerSupply = new PowerSupplyFactory().RepositoryInstances(powerSupplyInstance).Crate();

        PersonalComputer builder = new PersonalComputerBuilder()
            .Builder()
            .WithCase(casePc)
            .WithMotherboard(motherboard)
            .WithCentralProcessor(centralProcessor)
            .WithCoolingSystem(coolingSystem.CloneWithNewThermalDesignPower(50))
            .WithOperatingMemory(ram)
            .WithGraphicsCard(graphicsCard)
            .WithSolidStateDrive(ssd)
            .WithPowerSupplyUnit(powerSupply)
            .Build();

        Assert.True(CheckBuildingResults(builder));
    }
}