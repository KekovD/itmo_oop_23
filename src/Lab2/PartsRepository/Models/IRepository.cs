using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

public interface IRepository<T>
{
    IReadOnlyList<T> Repository { get; }

    void Add(T newItem);
}