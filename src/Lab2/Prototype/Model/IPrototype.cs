namespace Itmo.ObjectOrientedProgramming.Lab2.Prototype.Model;

public interface IPrototype<out T>
    where T : IPrototype<T>
{
    T Clone();
    T CloneWithNewName(string name);
}