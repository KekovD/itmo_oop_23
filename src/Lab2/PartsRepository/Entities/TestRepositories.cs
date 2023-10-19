using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public static class TestRepositories
{
    public static void AddObjects()
    {
        AddProcessors();
        AddMotherboards();
    }

    private static void AddProcessors()
    {
        const string firstName = "IntelPentiumGoldG6405";
        const int firstBiosVersion = 2;
        const int firstMemoryFrequencies = 2666;
        const int firstCoreFrequency = 4100;
        const int firstCoresNumber = 2;
        const int firstThermalDesignPower = 58;
        const int firstPowerConsumption = 58;

        var processor = new List<object>
        {
            firstName,                     new Lga1200(),
            new Intel64(firstBiosVersion), firstMemoryFrequencies,
            firstCoreFrequency,            firstCoresNumber,
            new IntelUHDGraphics610(),     firstThermalDesignPower,
            firstPowerConsumption,
        };

        Table.AddList(processor);

        const string secondName = "IntelCorei511400";
        const int secondBiosVersion = 3;
        const int secondMemoryFrequencies = 3200;
        const int secondCoreFrequency = 2600;
        const int secondCoresNumber = 6;
        const int secondThermalDesignPower = 65;
        const int secondPowerConsumption = 65;

        processor = new List<object>
        {
            secondName,                     new Lga1200(),
            new Intel64(secondBiosVersion), secondMemoryFrequencies,
            secondCoreFrequency,            secondCoresNumber,
            new IntelUHDGraphics730(),      secondThermalDesignPower,
            secondPowerConsumption,
        };

        Table.AddList(processor);

        const string thirdName = "IntelCorei312100";
        const int thirdBiosVersion = 4;
        const int thirdMemoryFrequencies = 4800;
        const int thirdCoreFrequency = 3300;
        const int thirdCoresNumber = 4;
        const int thirdThermalDesignPower = 89;
        const int thirdPowerConsumption = 89;

        processor = new List<object>
        {
            thirdName,                     new Lga1700(),
            new Intel64(thirdBiosVersion), thirdMemoryFrequencies,
            thirdCoreFrequency,            thirdCoresNumber,
            new IntelUHDGraphics730(),     thirdThermalDesignPower,
            thirdPowerConsumption,
        };

        Table.AddList(processor);

        const string fourthName = "IntelCorei713700F";
        const int fourthBiosVersion = 7;
        const int fourthMemoryFrequencies = 5600;
        const int fourthCoreFrequency = 2100;
        const int fourthCoresNumber = 8;
        const int fourthThermalDesignPower = 219;
        const int fourthPowerConsumption = 219;

        processor = new List<object>
        {
            fourthName,                     new Lga1700(),
            new Intel64(fourthBiosVersion), fourthMemoryFrequencies,
            fourthCoreFrequency,            fourthCoresNumber,
            new WithoutIntegratedVideoCore(),    fourthThermalDesignPower,
            fourthPowerConsumption,
        };

        Table.AddList(processor);
    }

    private static void AddMotherboards()
    {
        const string firstName = "GigabyteB560MH";
        const int firstPciENumber = 1;
        const int firstSataNumber = 4;
        const int firstMemoryFrequencies = 3200;
        const int firstRamTablesNumber = 2;
        const int firstBios = 6;

        var motherboard = new List<object>
        {
            firstName,              new Lga1200(),
            firstPciENumber,        firstSataNumber,
            firstMemoryFrequencies, new WithoutExtremeMemoryProfiles(),
            new Ddr4Motherboard(),  firstRamTablesNumber,
            new MicroAtx(),         new Intel64(firstBios),
        };

        Table.AddList(motherboard);

        const string secondName = "MSIH610TIS01";
        const int secondPciENumber = 0;
        const int secondSataNumber = 2;
        const int secondMemoryFrequencies = 3200;
        const int secondRamTablesNumber = 2;
        const int secondBios = 5;

        motherboard = new List<object>
        {
            secondName,              new Lga1700(),
            secondPciENumber,        secondSataNumber,
            secondMemoryFrequencies, new WithoutExtremeMemoryProfiles(),
            new Ddr4Motherboard(),   secondRamTablesNumber,
            new MiniItx(),           new Intel64(secondBios),
        };

        Table.AddList(motherboard);

        const string thirdName = "GigabyteZ790AorusMaster";
        const int thirdPciENumber = 3;
        const int thirdSataNumber = 4;
        const int thirdMemoryFrequencies = 5600;
        const int thirdRamTablesNumber = 4;
        const int thirdBios = 7;
        const int thirdRasToCas = 16;
        const int thirdRasPrecharge = 16;
        const int thirdTRas = 30;
        const int thirdTRc = 50;
        const int thirdVoltage = 2;
        const int thirdXmpFrequency = 6000;

        motherboard = new List<object>
        {
            thirdName,
            new Lga1700(),
            thirdPciENumber,
            thirdSataNumber,
            thirdMemoryFrequencies,
            new ExtremeMemoryProfiles(
                thirdRasToCas,
                thirdRasPrecharge,
                thirdTRas,
                thirdTRc,
                thirdVoltage,
                thirdXmpFrequency),
            new Ddr5Motherboard(),
            thirdRamTablesNumber,
            new Eatx(),
            new Intel64(thirdBios),
        };

        Table.AddList(motherboard);
    }

    private static void AddCoolingSystem()
    {
        const string firstName = "CoolerMasterHyperT200";
        const int firstHeight = 137;
        const int firstWidth = 112;
        const int firstLength = 84;
        const int firstThermalDesignPower = 100;

        var coolingSystem = new List<object>
        {
            firstName,
            new List<int> { firstHeight, firstWidth, firstLength },
            new List<SocketBase> { new Lga1200() },
            firstThermalDesignPower,
        };

        Table.AddList(coolingSystem);

        const string secondName = "DeepCoolAlta9";
        const int secondHeight = 59;
        const int secondWidth = 113;
        const int secondLength = 113;
        const int secondThermalDesignPower = 65;

        coolingSystem = new List<object>
        {
            secondName,
            new List<int> { secondHeight, secondWidth, secondLength },
            new List<SocketBase> { new Lga1700() },
            secondThermalDesignPower,
        };

        Table.AddList(coolingSystem);
    }
}