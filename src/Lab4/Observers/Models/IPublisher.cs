namespace Itmo.ObjectOrientedProgramming.Lab4.Observers.Models;

public interface IPublisher<out T>
{
    void Subscribe(IObserver<T> observer);
}