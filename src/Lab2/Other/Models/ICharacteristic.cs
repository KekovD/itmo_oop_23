namespace Itmo.ObjectOrientedProgramming.Lab2.Other.Models;

public interface ICharacteristic<out T>
{
    T Value { get; }
}