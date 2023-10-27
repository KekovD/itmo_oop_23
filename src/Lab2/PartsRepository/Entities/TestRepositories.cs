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

        const int firstBiosVersion = 2;
        const int firstMemoryFrequencies = 2666;
        const int firstCoreFrequency = 4100;
        const int firstCoresNumber = 2;
        const int firstThermalDesignPower = 58;
        const int firstPowerConsumption = 58;

        var processor = new List<object>
        {
            "IntelPentiumGoldG6405",                                  new SocketPc("Lga1200"),
            new Bios.Entities.BiosPc("Intel64", firstBiosVersion), firstMemoryFrequencies,
            firstCoreFrequency,                                       firstCoresNumber,
            new IntegratedVideoCore("IntelUHDGraphics610"),      firstThermalDesignPower,
            firstPowerConsumption,
        };

        repository.AddList(processor);

        const int secondBiosVersion = 6;
        const int secondMemoryFrequencies = 3200;
        const int secondCoreFrequency = 2600;
        const int secondCoresNumber = 6;
        const int secondThermalDesignPower = 65;
        const int secondPowerConsumption = 65;

        processor = new List<object>
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

        const int fourthBiosVersion = 7;
        const int fourthMemoryFrequencies = 5600;
        const int fourthCoreFrequency = 2100;
        const int fourthCoresNumber = 8;
        const int fourthThermalDesignPower = 219;
        const int fourthPowerConsumption = 219;

        processor = new List<object>
        {
            "IntelCorei713700F",                           new SocketPc("Lga1700"),
            new BiosPc("Intel64", fourthBiosVersion), fourthMemoryFrequencies,
            fourthCoreFrequency,                           fourthCoresNumber,
            new WithoutIntegratedVideoCore(),              fourthThermalDesignPower,
            fourthPowerConsumption,
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

        const int secondPciENumber = 0;
        const int secondSataNumber = 2;
        const int secondMemoryFrequencies = 3200;
        const int secondRamTablesNumber = 2;
        const int secondBios = 5;

        motherboard = new List<object>
        {
            "MSIH610TIS01",                                new SocketPc("Lga1700"),
            secondPciENumber,                          secondSataNumber,
            secondMemoryFrequencies,                   new WithoutExtremeMemoryProfiles(),
            new DdrMotherboard("Ddr4"),           secondRamTablesNumber,
            new FormFactorMotherboard("MiniItx"), new BiosPc("Intel64", secondBios),
            new WithoutPciE(),                         new WithoutIntegratedWiFi(),
        };

        repository.AddList(motherboard);

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
        const int secondPciE = 4;

        motherboard = new List<object>
        {
            "GigabyteZ790AorusMaster",
            new SocketPc("Lga1700"),
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
            new DdrMotherboard("Ddr5"),
            thirdRamTablesNumber,
            new FormFactorMotherboard("EAtx"),
            new BiosPc("Intel64", thirdBios),
            new PciE(secondPciE),
            new IntegratedWiFi(),
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

        const int secondHeight = 59;
        const int secondWidth = 113;
        const int secondLength = 113;
        const int secondThermalDesignPower = 65;

        coolingSystem = new List<object>
        {
            "DeepCoolAlta9",
            new List<int> { secondHeight, secondWidth, secondLength },
            new List<SocketBase> { new SocketPc("Lga1700") },
            secondThermalDesignPower,
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

        const int secondMemorySize = 16;
        const int secondCardsNumber = 4;
        const int secondRasToCasJedec = 36;
        const int secondRasPrechargeJedec = 38;
        const int secondTRasJedec = 38;
        const int secondTRcJedec = 38;
        const int secondVoltageJedec = 1;
        const int secondFrequencyJedec = 4800;
        const int secondRasToCasXmp = 36;
        const int secondRasPrechargeXmp = 38;
        const int secondTRasXmp = 38;
        const int secondTRcXmp = 38;
        const int secondVoltageXmp = 1;
        const int secondFrequencyXmp = 4800;
        const int secondPowerConsumption = 7;

        ram = new List<object>
        {
            "KingstonFURYRenegadePro",
            secondMemorySize,
            secondCardsNumber,
            new Jedec(
                secondRasToCasJedec,
                secondRasPrechargeJedec,
                secondTRasJedec,
                secondTRcJedec,
                secondVoltageJedec,
                secondFrequencyJedec),
            new ExtremeMemoryProfiles(
                secondRasToCasXmp,
                secondRasPrechargeXmp,
                secondTRasXmp,
                secondTRcXmp,
                secondVoltageXmp,
                secondFrequencyXmp),
            new RamFormFactor.Entities.RamFormFactor("RDimm"),
            new DdrMotherboard("Ddr5"),
            secondPowerConsumption,
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

        const int secondHeight = 120;
        const int secondWidth = 230;
        const int secondVideoMemoryNumber = 8;
        const int secondChipFrequency = 1410;
        const int secondPowerConsumption = 110;
        const int secondPciE = 4;

        graphicsCard = new List<object>
        {
            "ASUSGeForceRTX3060TiDual", secondHeight,
            secondWidth,                secondVideoMemoryNumber,
            new PciE(secondPciE),       secondChipFrequency,
            secondPowerConsumption,
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

        const int secondCapacity = 1000;
        const int secondMaximumSpeed = 3500;
        const int secondPowerConsumption = 3;

        ssd = new List<object>
        {
            "Samsung980",           new SsdPciE(),
            secondCapacity,         secondMaximumSpeed,
            secondPowerConsumption,
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

        const int secondCapacity = 1000;
        const int secondSpindleSpeed = 5400;
        const int secondPowerConsumption = 4;

        hdd = new List<object>
        {
            "WDPurple",         secondCapacity,
            secondSpindleSpeed, secondPowerConsumption,
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

        const int secondMaximumLength = 375;
        const int secondMaximumWidth = 150;
        const int secondLength = 411;
        const int secondWidth = 195;
        const int secondHeight = 410;

        pcCase = new List<object>
        {
            "AeroCoolCS-1101",
            secondMaximumLength,
            secondMaximumWidth,
            new List<FormFactorMotherboardBase>
            {
                new FormFactorMotherboard("MicroAtx"),
                new FormFactorMotherboard("MiniItx"),
                new FormFactorMotherboard("Atx"),
            },
            secondLength,
            secondWidth,
            secondHeight,
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

        const string secondName = "DeepCoolPX1000G";
        const int secondPeakLoad = 1000;

        powerSupply = new List<object>
        {
            secondName,
            secondPeakLoad,
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