namespace Itmo.ObjectOrientedProgramming.Lab4.Observers.Models;

public interface IObserver<in T>
{
    void OnNext(T value);
}