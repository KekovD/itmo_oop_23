using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

public static class Table
{
    public static IReadOnlyList<IReadOnlyList<object>> Repository { get; private set; } =
        new List<IReadOnlyList<object>>();

    public static IList<object> GetByName(string name)
    {
        if (Table.Repository is not null)
        {
            foreach (IReadOnlyList<object> repository in Table.Repository)
            {
                if (name.Equals((string)repository[0], StringComparison.Ordinal))
                {
                    return new List<object>(repository);
                }
            }

            throw new GetByNameNullException();
        }

        throw new RepositoryNullException(nameof(GetByName));
    }

    public static void AddList(IList<object> newItem)
    {
        var newRepository = new List<IReadOnlyList<object>>(Repository) { newItem.ToList().AsReadOnly() };
        Repository = newRepository;
    }
}