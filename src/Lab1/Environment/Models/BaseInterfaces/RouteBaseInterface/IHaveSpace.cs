using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;

public interface IHaveSpace<T>
{
    IReadOnlyCollection<string> Space { get; }
}