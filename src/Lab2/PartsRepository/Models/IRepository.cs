using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CasePc.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.OptionalWiFiModule.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupplyUnit.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.SsdMemory.Models;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

public interface IRepository
{
    IList<object> Find(string name);
    void AddList(IList<object> newItem);
    void Add(PcCase newItem);
    void Add(CentralProcessorBase newItem);
    void Add(CoolingSystemBase newItem);
    void Add(GraphicsCardBase newItem);
    void Add(HddBase newItem);
    void Add(MotherboardBase newItem);
    void Add(PowerSupplyBase newItem);
    void Add(RamBase newItem);
    void Add(SsdBase newItem);
    void Add(WiFiModuleBase newItem);
}