using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public static class CentralProcessorRepository
{
    public static void Add(CentralProcessorBase newItem)
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

        Table.AddList(newItemList);
    }
}