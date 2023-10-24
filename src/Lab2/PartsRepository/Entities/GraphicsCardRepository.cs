using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public static class GraphicsCardRepository
{
    public static void Add(GraphicsCardBase newItem)
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

        Table.AddList(newItemList);
    }
}