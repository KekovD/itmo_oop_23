using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Other.Models.Characteristic;

public abstract class Socket : ICharacteristic<string?>, ICheckComponentValid
{
    public string? Value { get; protected init; }
    public bool ComponentValid { get; private set; }

    public void CheckComponentValid(ICheckComponentValid characteristic)
    {
        if (Value is null) return;

        if (characteristic is Socket socket)
        {
            ComponentValid = Value.Equals(socket.Value, StringComparison.Ordinal);
        }
    }
}