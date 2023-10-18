using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

public interface IRepository<T>
{
    void Add(T newItem);

    IList<object> GetByName(string name);

    void AddList(IList<object> newItem);
}