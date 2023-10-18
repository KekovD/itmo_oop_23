using Itmo.ObjectOrientedProgramming.Lab2.PC.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IFactory
{
    IPart CreateByName(string name);
}