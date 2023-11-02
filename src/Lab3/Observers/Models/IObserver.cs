namespace Itmo.ObjectOrientedProgramming.Lab3.Observers.Models;

public interface IObserver<in T>
{
    void OnNext(T value);
}