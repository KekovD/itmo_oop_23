using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public static class CoolingSystemRepository
{
    public static void Add(CoolingSystemBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.Dimensions,
            newItem.SupportedSockets,
            newItem.ThermalDesignPower,
        };

        Table.AddList(newItemList);
    }
}