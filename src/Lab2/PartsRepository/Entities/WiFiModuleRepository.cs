using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public static class WiFiModuleRepository
{
    public static void Add(WiFiModuleBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.StandardVersion,
            newItem.PciEVersion,
            newItem.BuiltInBluetooth,
            newItem.PowerConsumption,
        };

        Table.AddList(newItemList);
    }
}