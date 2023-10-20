using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public class MotherboardRepository : RepositoryBase<MotherboardBase>
{
    public override void Add(MotherboardBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.Socket,
            newItem.PciENumber,
            newItem.SataNumber,
            newItem.MemoryFrequencies,
            newItem.ExtremeMemoryProfiles,
            newItem.DdrMotherboard,
            newItem.RamTablesNumber,
            newItem.FormFactor,
            newItem.Bios,
            newItem.PciEVersion,
            newItem.IntegratedWiFi,
        };

        Table.AddList(newItemList);
    }
}