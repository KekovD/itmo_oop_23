using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.LabException;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

public abstract class RepositoryBase<T>
{
    public abstract void Add(T newItem);

    public IList<object>? GetByName(string name)
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

            return null;
        }

        throw new RepositoryNullException(nameof(GetByName));
    }
}