using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models.Cpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entity;

public class CentralProcessorRepository : IRepository<CentralProcessorTemplate>
{
    public CentralProcessorRepository()
    {
        Parts = new List<CentralProcessorTemplate>();
    }

    public IReadOnlyList<CentralProcessorTemplate> Parts { get; private set; }

    public void Add(CentralProcessorTemplate newPart)
    {
        var newRepository = new List<CentralProcessorTemplate>(Parts) { newPart };
        Parts = newRepository;
    }
}