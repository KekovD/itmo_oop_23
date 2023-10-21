﻿using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.CpuIntegratedVideoCore.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.IntegratedWiFiModule.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.MotherboardFormFactor.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcieVersion.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RamFormFactor.Entities;
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
        const int secondBiosVersion = 6;
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
            new PciE4(),            new WithoutIntegratedWiFi(),
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
            new WithoutPciE(),       new WithoutIntegratedWiFi(),
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
            new PciE4(),
            new IntegratedWiFi(),
        };

        Table.AddList(motherboard);
    }

    private static void AddCoolingSystem()
    {
        const string firstName = "DeepcoolGammaxx300";
        const int firstHeight = 136;
        const int firstWidth = 121;
        const int firstLength = 76;
        const int firstThermalDesignPower = 130;

        var coolingSystem = new List<object>
        {
            firstName,
            new List<int> { firstHeight, firstWidth, firstLength },
            new List<SocketBase> { new Lga1200(), new Lga1700() },
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

    private static void AddRam()
    {
        const string firstName = "DEXP8GD4UD32";
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
            firstName,
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
            new Dimm(),
            new Ddr4Motherboard(),
            firstPowerConsumption,
        };

        Table.AddList(ram);

        const string secondName = "KingstonFURYRenegadePro";
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
            secondName,
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
            new RDimm(),
            new Ddr5Motherboard(),
            secondPowerConsumption,
        };

        Table.AddList(ram);
    }

    private static void AddGraphicsCard()
    {
        const string firstName = "PalitGeForceRTX3050Dual";
        const int firstHeight = 120;
        const int firstWidth = 172;
        const int firstVideoMemoryNumber = 8;
        const int firstChipFrequency = 1552;
        const int firstPowerConsumption = 115;

        var graphicsCard = new List<object>
        {
            firstName,             firstHeight,
            firstWidth,            firstVideoMemoryNumber,
            new PciE4(),           firstChipFrequency,
            firstPowerConsumption,
        };

        Table.AddList(graphicsCard);

        const string secondName = "ASUSGeForceRTX3060TiDual";
        const int secondHeight = 120;
        const int secondWidth = 230;
        const int secondVideoMemoryNumber = 8;
        const int secondChipFrequency = 1410;
        const int secondPowerConsumption = 110;

        graphicsCard = new List<object>
        {
            secondName,             secondHeight,
            secondWidth,            secondVideoMemoryNumber,
            new PciE4(),            secondChipFrequency,
            secondPowerConsumption,
        };

        Table.AddList(graphicsCard);
    }

    private static void AddSsd()
    {
        const string firstName = "CrucialBX500";
        const int firstCapacity = 1000;
        const int firstMaximumSpeed = 540;
        const int firstPowerConsumption = 1;

        var ssd = new List<object>
        {
            firstName,             new SsdSata(),
            firstCapacity,         firstMaximumSpeed,
            firstPowerConsumption,
        };

        Table.AddList(ssd);

        const string secondName = "Samsung980";
        const int secondCapacity = 1000;
        const int secondMaximumSpeed = 3500;
        const int secondPowerConsumption = 3;

        ssd = new List<object>
        {
            secondName,             new SsdPciE(),
            secondCapacity,         secondMaximumSpeed,
            secondPowerConsumption,
        };

        Table.AddList(ssd);
    }

    private static void AddHdd()
    {
        const string firstName = "ToshibaDT01";
        const int firstCapacity = 1000;
        const int firstSpindleSpeed = 7200;
        const int firstPowerConsumption = 7;

        var hdd = new List<object>
        {
            firstName,         firstCapacity,
            firstSpindleSpeed, firstPowerConsumption,
        };

        Table.AddList(hdd);

        const string secondName = "WDPurple";
        const int secondCapacity = 1000;
        const int secondSpindleSpeed = 5400;
        const int secondPowerConsumption = 4;

        hdd = new List<object>
        {
            secondName,         secondCapacity,
            secondSpindleSpeed, secondPowerConsumption,
        };

        Table.AddList(hdd);
    }

    private static void AddCase()
    {
        const string firstName = "DeepcoolMatrexx30";
        const int firstMaximumLength = 250;
        const int firstMaximumWidth = 151;
        const int firstLength = 406;
        const int firstWidth = 193;
        const int firstHeight = 379;

        var pcCase = new List<object>
        {
            firstName,         firstMaximumLength,
            firstMaximumWidth, new List<FormFactorMotherboardBase> { new MicroAtx(), new MiniItx() },
            firstLength,       firstWidth,
            firstHeight,
        };

        Table.AddList(pcCase);

        const string secondName = "AeroCoolCS-1101";
        const int secondMaximumLength = 375;
        const int secondMaximumWidth = 150;
        const int secondLength = 411;
        const int secondWidth = 195;
        const int secondHeight = 410;

        pcCase = new List<object>
        {
            secondName,         secondMaximumLength,
            secondMaximumWidth, new List<FormFactorMotherboardBase> { new MicroAtx(), new MiniItx(), new Atx() },
            secondLength,       secondWidth,
            secondHeight,
        };

        Table.AddList(pcCase);
    }

    private static void AddPowerSupply()
    {
        const string firstName = "AeroCoolECO600W";
        const int firstPeakLoad = 600;

        var powerSupply = new List<object>
        {
            firstName,
            firstPeakLoad,
        };

        Table.AddList(powerSupply);

        const string secondName = "DeepCoolPX1000G";
        const int secondPeakLoad = 1000;

        powerSupply = new List<object>
        {
            secondName,
            secondPeakLoad,
        };

        Table.AddList(powerSupply);
    }

    private static void AddWiFiModule()
    {
        const string firstName = "BluetoothAsusPCEAX3000";
        const string firstStandardVersion = "802.11n";
        const int firstPowerConsumption = 3;

        var wiFiModule = new List<object>
        {
            firstName,             firstStandardVersion,
            new PciE4(),           new BuiltInBluetooth(),
            firstPowerConsumption,
        };

        Table.AddList(wiFiModule);
    }
}