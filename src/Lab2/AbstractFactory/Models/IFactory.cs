namespace Itmo.ObjectOrientedProgramming.Lab2.AbstractFactory.Models;

public interface IFactory<out T>
{
    T Create();
}