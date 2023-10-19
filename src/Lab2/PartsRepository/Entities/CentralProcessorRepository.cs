using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public class CentralProcessorRepository : IRepository<CentralProcessorBase>
{
    public static IReadOnlyList<IReadOnlyList<object>>? Repository { get; private set; } = new List<IReadOnlyList<object>>();

    public void Add(CentralProcessorBase newItem)
    {
        var newItemList = new List<object>
        {
            newItem.Name,
            newItem.Socket,
            newItem.Bios,
            newItem.MemoryFrequencies,
            newItem.CoreFrequency,
            newItem.CoresNumber,
            newItem.IntegratedVideoCore,
            newItem.ThermalDesignPower,
            newItem.PowerConsumption,
        };

        if (Repository is not null)
        {
            var newRepository = new List<IReadOnlyList<object>>(Repository) { newItemList };
            Repository = newRepository;
            return;
        }

        var newRepositorySecond = new List<IReadOnlyList<object>> { newItemList };
        Repository = newRepositorySecond;
    }

    public IList<object> GetByName(string name)
    {
        if (Repository is not null)
        {
            foreach (IReadOnlyList<object> repository in Repository)
            {
                if (name.Equals((string)repository[0], StringComparison.Ordinal))
                {
                    return new List<object>(repository);
                }
            }
        }

        throw new NameNotFoundException(nameof(CentralProcessorRepository));
    }

    public void AddList(IList<object> newItem)
    {
        if (Repository is not null)
        {
            var newRepository = new List<IReadOnlyList<object>>(Repository) { newItem.ToList().AsReadOnly() };
            Repository = newRepository;
            return;
        }

        var newRepositorySecond = new List<IReadOnlyList<object>>() { newItem.ToList().AsReadOnly() };
        Repository = newRepositorySecond;
    }
}