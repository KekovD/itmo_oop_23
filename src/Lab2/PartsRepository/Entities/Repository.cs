using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public class Repository : IRepository
{
    private static IReadOnlyList<IReadOnlyList<object>> Table { get; set; } =
        new List<IReadOnlyList<object>>();

    public IList<object> Find(string name) =>
        Table
            .FirstOrDefault(repository =>
                name.Equals((string)repository[0], StringComparison.Ordinal))?
            .ToList()
            ?? throw new GetByNameNullException();

    public void AddList(IList<object> newItem)
    {
        var newRepository = new List<IReadOnlyList<object>>(Table) { newItem.ToList().AsReadOnly() };
        Table = newRepository;
    }

    public void Add(PcCase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.MaximumLength,
            newItem.MaximumWidth,
            newItem.MotherboardFormFactors,
            newItem.Length,
            newItem.Width,
            newItem.Height,
        };

        AddList(newItemList);
    }

    public void Add(CentralProcessorBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.Socket,
            newItem.Bios,
            newItem.MemoryFrequencies,
            newItem.CoreFrequency,
            newItem.CoresNumber,
            newItem.IntegratedVideoCore,
            newItem.ThermalDesignPower,
            newItem.PowerConsumption,
        };

        AddList(newItemList);
    }

    public void Add(CoolingSystemBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.Dimensions,
            newItem.SupportedSockets,
            newItem.ThermalDesignPower,
        };

        AddList(newItemList);
    }

    public void Add(GraphicsCardBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.Height,
            newItem.Width,
            newItem.VideoMemoryNumber,
            newItem.PciEVersion,
            newItem.ChipFrequency,
            newItem.PowerConsumption,
        };

        AddList(newItemList);
    }

    public void Add(HddBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.Capacity,
            newItem.SpindleSpeed,
            newItem.PowerConsumption,
        };

        AddList(newItemList);
    }

    public void Add(MotherboardBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.Socket,
            newItem.PciENumber,
            newItem.SataNumber,
            newItem.MemoryFrequencies,
            newItem.ExtremeMemoryProfiles,
            newItem.DdrMotherboard,
            newItem.RamTablesNumber,
            newItem.FormFactor,
            newItem.Bios,
            newItem.PciEVersion,
            newItem.IntegratedWiFi,
        };

        AddList(newItemList);
    }

    public void Add(PowerSupplyBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.PeakLoad,
        };

        AddList(newItemList);
    }

    public void Add(RamBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.MemorySize,
            newItem.CardsNumber,
            newItem.JedecProfile,
            newItem.ExtremeMemoryProfile,
            newItem.RamFormFactor,
            newItem.DdrType,
            newItem.PowerConsumption,
        };

        AddList(newItemList);
    }

    public void Add(SsdBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.ConnectionOption,
            newItem.Capacity,
            newItem.MaximumSpeed,
            newItem.PowerConsumption,
        };

        AddList(newItemList);
    }

    public void Add(WiFiModuleBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.StandardVersion,
            newItem.PciEVersion,
            newItem.BuiltInBluetooth,
            newItem.PowerConsumption,
        };

        AddList(newItemList);
    }
}