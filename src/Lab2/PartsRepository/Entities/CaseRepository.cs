using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public static class CaseRepository
{
    public static void Add(PcCase newItem)
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

        new Repository().AddList(newItemList);
    }
}