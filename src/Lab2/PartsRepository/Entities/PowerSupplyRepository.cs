using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public class PowerSupplyRepository : RepositoryBase<PowerSupplyBase>
{
    public override void Add(PowerSupplyBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.PeakLoad,
        };

        Table.AddList(newItemList);
    }
}