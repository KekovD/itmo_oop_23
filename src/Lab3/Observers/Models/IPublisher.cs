namespace Itmo.ObjectOrientedProgramming.Lab3.Observers.Models;

public interface IPublisher<out T>
{
    void Subscribe(IObserver<T> observer);
}