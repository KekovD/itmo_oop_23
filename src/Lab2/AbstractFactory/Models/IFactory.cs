using Itmo.ObjectOrientedProgramming.Lab2.PC.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IFactory
{
    IPart CreateByName(string name);
}