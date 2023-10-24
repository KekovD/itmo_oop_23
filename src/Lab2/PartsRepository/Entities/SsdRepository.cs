using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public static class SsdRepository
{
    public static void Add(SsdBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.ConnectionOption,
            newItem.Capacity,
            newItem.MaximumSpeed,
            newItem.PowerConsumption,
        };

        Table.AddList(newItemList);
    }
}