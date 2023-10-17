using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity.Lga1200;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity.Lga1700;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entity;

public class CentralProcessorRepository : IRepository<CentralProcessorBase>
{
    public IReadOnlyList<CentralProcessorBase> Repository { get; private set; } = new List<CentralProcessorBase>
    {
        new IntelPentiumGoldG6405(),
        new IntelCorei312100(),
        new IntelCorei511400(),
        new IntelCorei713700F(),
    };

    public void Add(CentralProcessorBase newItem)
    {
        Repository = new List<CentralProcessorBase>(Repository) { newItem };
    }
}