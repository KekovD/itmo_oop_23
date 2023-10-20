using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public class GraphicsCardRepository : RepositoryBase<GraphicsCardBase>
{
    public override void Add(GraphicsCardBase newItem)
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