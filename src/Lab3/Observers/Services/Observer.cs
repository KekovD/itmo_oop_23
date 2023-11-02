using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Observers.Services;

public class Observer<T> : Models.IObserver<T>
{
    private readonly Action<T> _action;

    public Observer(Action<T> action) => _action = action;

    public void OnNext(T value) => _action.Invoke(value);
}