using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.IntegratedWiFiModule.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Socket.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdType.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiBuiltInBluetooth.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Xmp.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public class TestRepositories : ITestRepository
{
    public void AddObjects()
    {
        AddProcessors();
        AddMotherboards();
        AddCoolingSystem();
        AddRam();
        AddGraphicsCard();
        AddSsd();
        AddHdd();
        AddCase();
        AddPowerSupply();
        AddWiFiModule();
    }

    private static void AddProcessors()
    {
        var repository = new Repository();

        const int secondBiosVersion = 6;
        const int secondMemoryFrequencies = 3200;
        const int secondCoreFrequency = 2600;
        const int secondCoresNumber = 6;
        const int secondThermalDesignPower = 65;
        const int secondPowerConsumption = 65;

        var processor = new List<object>
        {
            "IntelCorei511400",                                        new SocketPc("Lga1200"),
            new Bios.Entities.BiosPc("Intel64", secondBiosVersion), secondMemoryFrequencies,
            secondCoreFrequency,                                       secondCoresNumber,
            new IntegratedVideoCore("IntelUHDGraphics730"),       secondThermalDesignPower,
            secondPowerConsumption,
        };

        repository.AddList(processor);

        const int thirdBiosVersion = 4;
        const int thirdMemoryFrequencies = 4800;
        const int thirdCoreFrequency = 3300;
        const int thirdCoresNumber = 4;
        const int thirdThermalDesignPower = 89;
        const int thirdPowerConsumption = 89;

        processor = new List<object>
        {
            "IntelCorei312100",                                  new SocketPc("Lga1700"),
            new BiosPc("Intel64", thirdBiosVersion),        thirdMemoryFrequencies,
            thirdCoreFrequency,                                  thirdCoresNumber,
            new IntegratedVideoCore("IntelUHDGraphics730"), thirdThermalDesignPower,
            thirdPowerConsumption,
        };

        repository.AddList(processor);
    }

    private static void AddMotherboards()
    {
        var repository = new Repository();

        const int firstPciENumber = 1;
        const int firstSataNumber = 4;
        const int firstMemoryFrequencies = 3200;
        const int firstRamTablesNumber = 2;
        const int firstBios = 6;
        const int firstPciE = 4;

        var motherboard = new List<object>
        {
            "GigabyteB560MH",                           new SocketPc("Lga1200"),
            firstPciENumber,                            firstSataNumber,
            firstMemoryFrequencies,                     new WithoutExtremeMemoryProfiles(),
            new DdrMotherboard("Ddr4"),            firstRamTablesNumber,
            new FormFactorMotherboard("MicroAtx"), new BiosPc("Intel64", firstBios),
            new PciE(firstPciE),                        new WithoutIntegratedWiFi(),
        };

        repository.AddList(motherboard);
    }

    private static void AddCoolingSystem()
    {
        var repository = new Repository();

        const int firstHeight = 136;
        const int firstWidth = 121;
        const int firstLength = 76;
        const int firstThermalDesignPower = 130;

        var coolingSystem = new List<object>
        {
            "DeepcoolGammaxx300",
            new List<int> { firstHeight, firstWidth, firstLength },
            new List<SocketBase> { new SocketPc("Lga1200"), new SocketPc("Lga1700") },
            firstThermalDesignPower,
        };

        repository.AddList(coolingSystem);
    }

    private static void AddRam()
    {
        var repository = new Repository();

        const int firstMemorySize = 8;
        const int firstCardsNumber = 2;
        const int firstRasToCasJedec = 22;
        const int firstRasPrechargeJedec = 22;
        const int firstTRasJedec = 22;
        const int firstTRcJedec = 52;
        const int firstVoltageJedec = 2;
        const int firstFrequencyJedec = 3200;
        const int firstPowerConsumption = 8;

        var ram = new List<object>
        {
            "DEXP8GD4UD32",
            firstMemorySize,
            firstCardsNumber,
            new Jedec(
                firstRasToCasJedec,
                firstRasPrechargeJedec,
                firstTRasJedec,
                firstTRcJedec,
                firstVoltageJedec,
                firstFrequencyJedec),
            new WithoutExtremeMemoryProfiles(),
            new RamFormFactor.Entities.RamFormFactor("Dimm"),
            new DdrMotherboard("Ddr4"),
            firstPowerConsumption,
        };

        repository.AddList(ram);
    }

    private static void AddGraphicsCard()
    {
        var repository = new Repository();

        const int firstHeight = 120;
        const int firstWidth = 172;
        const int firstVideoMemoryNumber = 8;
        const int firstChipFrequency = 1552;
        const int firstPowerConsumption = 115;
        const int firstPciE = 4;

        var graphicsCard = new List<object>
        {
            "PalitGeForceRTX3050Dual", firstHeight,
            firstWidth,                firstVideoMemoryNumber,
            new PciE(firstPciE),       firstChipFrequency,
            firstPowerConsumption,
        };

        repository.AddList(graphicsCard);
    }

    private static void AddSsd()
    {
        var repository = new Repository();

        const int firstCapacity = 1000;
        const int firstMaximumSpeed = 540;
        const int firstPowerConsumption = 1;

        var ssd = new List<object>
        {
            "CrucialBX500",        new SsdSata(),
            firstCapacity,         firstMaximumSpeed,
            firstPowerConsumption,
        };

        repository.AddList(ssd);
    }

    private static void AddHdd()
    {
        var repository = new Repository();

        const int firstCapacity = 1000;
        const int firstSpindleSpeed = 7200;
        const int firstPowerConsumption = 7;

        var hdd = new List<object>
        {
            "ToshibaDT01",         firstCapacity,
            firstSpindleSpeed, firstPowerConsumption,
        };

        repository.AddList(hdd);
    }

    private static void AddCase()
    {
        var repository = new Repository();

        const int firstMaximumLength = 250;
        const int firstMaximumWidth = 151;
        const int firstLength = 406;
        const int firstWidth = 193;
        const int firstHeight = 379;

        var pcCase = new List<object>
        {
            "DeepcoolMatrexx30",
            firstMaximumLength,
            firstMaximumWidth,
            new List<FormFactorMotherboardBase>
            {
                new FormFactorMotherboard("MicroAtx"),
                new FormFactorMotherboard("MiniItx"),
            },
            firstLength,
            firstWidth,
            firstHeight,
        };

        repository.AddList(pcCase);
    }

    private static void AddPowerSupply()
    {
        var repository = new Repository();

        const string firstName = "AeroCoolECO600W";
        const int firstPeakLoad = 600;

        var powerSupply = new List<object>
        {
            firstName,
            firstPeakLoad,
        };

        repository.AddList(powerSupply);
    }

    private static void AddWiFiModule()
    {
        var repository = new Repository();

        const string firstName = "BluetoothAsusPCEAX3000";
        const string firstStandardVersion = "802.11n";
        const int firstPowerConsumption = 3;
        const int firstPcie = 4;

        var wiFiModule = new List<object>
        {
            firstName,              firstStandardVersion,
            new PciE(firstPcie), new BuiltInBluetooth(),
            firstPowerConsumption,
        };

        repository.AddList(wiFiModule);
    }
}