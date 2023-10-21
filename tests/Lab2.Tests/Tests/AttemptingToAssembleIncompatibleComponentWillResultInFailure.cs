using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Services;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcBuilder.Services;
using Itmo.ObjectOrientedProgramming.Lab2.PcChecker.Services;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public class AttemptingToAssembleIncompatibleComponentWillResultInFailure
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
                    "IntelCorei312100",
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
        if (builder.Message.Count == 2 && builder.Message[0] == BuildStatus.UnsuitableSocketType &&
            builder.Message[1] == BuildStatus.UnsuitableMotherboardBiosVersion)
            return true;

        return false;
    }

    [Theory]
    [MemberData(nameof(GetParts), MemberType = typeof(AttemptingToAssembleIncompatibleComponentWillResultInFailure))]
    private void ConditionCheck(IList<string> parts)
    {
        new TestRepositories().AddObjects();
        IPart casePc = new PcCaseFactory().CreateByName(parts[0]);
        IPart motherboard = new MotherboardFactory().CreateByName(parts[1]);
        IPart centralProcessor = new CentralProcessorFactory().CreateByName(parts[2]);
        IPart coolingSystem = new CoolingSystemFactory().CreateByName(parts[3]);
        IPart ram = new RamFactory().CreateByName(parts[4]);
        IPart graphics = new GraphicsCardFactory().CreateByName(parts[5]);
        IPart ssd = new SsdFactory().CreateByName(parts[6]);
        IPart powerSupply = new PowerSupplyFactory().CreateByName(parts[7]);

        PersonalComputer builder = new PersonalComputerBuilder()
            .Builder()
            .WithCase((CaseBase)casePc)
            .WithMotherboard((MotherboardBase)motherboard)
            .WithCentralProcessor((CentralProcessorBase)centralProcessor)
            .WithCoolingSystem((CoolingSystemBase)coolingSystem)
            .WithOperatingMemory((RamBase)ram)
            .WithGraphicsCard((GraphicsCardBase)graphics)
            .WithSolidStateDrive((SsdBase)ssd)
            .WithPowerSupplyUnit((PowerSupplyBase)powerSupply)
            .Build();

        Assert.True(CheckBuildingResults(builder));
    }
}