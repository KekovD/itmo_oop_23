using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;
using Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Entities;

public class Repository : IRepository
{
    private static IReadOnlyList<IReadOnlyList<object>> Table { get; set; } =
        new List<IReadOnlyList<object>>();

    public IList<object> Find(string name) =>
        Table
            .FirstOrDefault(repository =>
                name.Equals((string)repository[0], StringComparison.Ordinal))?
            .ToList()
            ?? throw new GetByNameNullException();

    public void AddList(IList<object> newItem)
    {
        var newRepository = new List<IReadOnlyList<object>>(Table) { newItem.ToList().AsReadOnly() };
        Table = newRepository;
    }
}