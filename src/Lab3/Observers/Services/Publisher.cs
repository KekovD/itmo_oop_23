using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Observers.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Observers.Services;

public class Publisher<T> : IPublisher<T>
{
    private readonly IList<IObserver<T>> _observers = new List<IObserver<T>>();

    public void Subscribe(IObserver<T> observer) => _observers.Add(observer);

    public void SendNext(T value)
    {
        foreach (IObserver<T> observer in _observers)
            observer.OnNext(value);
    }
}