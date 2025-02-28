﻿using Itmo.ObjectOrientedProgramming.Lab2.Mainboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.SsdType.Models;

public abstract class SsdTypeBase : IPrototype<SsdTypeBase>
{
    public string? Name { get; protected init; }

    public abstract SsdTypeBase Clone();

    public abstract bool InstallingSsd(ref MotherboardBase motherboard);
}