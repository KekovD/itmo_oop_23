using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

public interface IRepository<T>
{
    IReadOnlyList<T> Parts { get; }

    void Add(T newPart);
}