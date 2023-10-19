using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public static class TestRepositories
{
    public static void AddObjectsForTest()
    {
        AddProcessors();
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

        const string secondName = "IntelCorei511400";
        const int secondBiosVersion = 3;
        const int secondMemoryFrequencies = 3200;
        const int secondCoreFrequency = 2600;
        const int secondCoresNumber = 6;
        const int secondThermalDesignPower = 65;
        const int secondPowerConsumption = 65;

        const string thirdName = "IntelCorei312100";
        const int thirdBiosVersion = 4;
        const int thirdMemoryFrequencies = 4800;
        const int thirdCoreFrequency = 3300;
        const int thirdCoresNumber = 4;
        const int thirdThermalDesignPower = 89;
        const int thirdPowerConsumption = 89;

        const string fourthName = "IntelCorei713700F";
        const int fourthBiosVersion = 7;
        const int fourthMemoryFrequencies = 5600;
        const int fourthCoreFrequency = 2100;
        const int fourthCoresNumber = 8;
        const int fourthThermalDesignPower = 219;
        const int fourthPowerConsumption = 219;

        var repository = new CentralProcessorRepository();

        var processor = new List<object>
        {
            firstName,                     new Lga1200(),
            new Intel64(firstBiosVersion), firstMemoryFrequencies,
            firstCoreFrequency,            firstCoresNumber,
            new IntelUHDGraphics610(),     firstThermalDesignPower,
            firstPowerConsumption,
        };

        repository.AddList(processor);

        processor = new List<object>
        {
            secondName,                     new Lga1200(),
            new Intel64(secondBiosVersion), secondMemoryFrequencies,
            secondCoreFrequency,            secondCoresNumber,
            new IntelUHDGraphics730(),      secondThermalDesignPower,
            secondPowerConsumption,
        };

        repository.AddList(processor);

        processor = new List<object>
        {
            thirdName,                     new Lga1700(),
            new Intel64(thirdBiosVersion), thirdMemoryFrequencies,
            thirdCoreFrequency,            thirdCoresNumber,
            new IntelUHDGraphics730(),     thirdThermalDesignPower,
            thirdPowerConsumption,
        };

        repository.AddList(processor);

        processor = new List<object>
        {
            fourthName,                     new Lga1700(),
            new Intel64(fourthBiosVersion), fourthMemoryFrequencies,
            fourthCoreFrequency,            fourthCoresNumber,
            new NoIntegratedVideoCore(),    fourthThermalDesignPower,
            fourthPowerConsumption,
        };

        repository.AddList(processor);
    }
}