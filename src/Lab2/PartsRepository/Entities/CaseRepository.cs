using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public class CaseRepository : RepositoryBase<PcCase>
{
    public override void Add(PcCase newItem)
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

        Table.AddList(newItemList);
    }
}