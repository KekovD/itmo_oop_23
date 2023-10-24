using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public static class RamRepository
{
    public static void Add(RamBase newItem)
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

        Table.AddList(newItemList);
    }
}