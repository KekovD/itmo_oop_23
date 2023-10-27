using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models;

public interface IRepository
{
    IList<object> Find(string name);
    void AddList(IList<object> newItem);
}