using Itmo.ObjectOrientedProgramming.Lab2.WiFiBuiltInBluetooth.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiBuiltInBluetooth.Entities;

public class BuiltInBluetooth : IBuiltInBluetooth
{
    public IBuiltInBluetooth Clone() => new BuiltInBluetooth();
}