using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IFactory
{
    public IFactory RepositoryInstances(IList<object> instances);
    public IPart Crate();
}