using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public static class HddRepository
{
    public static void Add(HddBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.Capacity,
            newItem.SpindleSpeed,
            newItem.PowerConsumption,
        };

        Table.AddList(newItemList);
    }
}